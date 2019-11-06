using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SplatfestEditor.Splatoon;
using System.IO;
using System.Media;

namespace SplatfestEditor
{
    public partial class MainForm : Form
    {
        public const string BYAML_FILTER = "Byaml Files (*.byaml; *.byml)|*.byaml;*.byml|All Files (*.*)|*.*";

        ByamlFestival fest;
        int updatingControl = 0;

        public MainForm()
        {
            InitializeComponent();

            foreach (var item in ByamlFestival.SplatoonLangs)
                toolStripComboBox_Langs.Items.Add(item);
            foreach (var item in ByamlFestival.CameraTypes)
                comboBox_cameraType.Items.Add(item);
            foreach (var item in ByamlFestival.Emotions)
                comboBox_emotion.Items.Add(item);
            foreach (var item in ByamlFestival.Speakers)
                comboBox_speaker.Items.Add(item);

            toolStripComboBox_Langs.SelectedIndex = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = BYAML_FILTER;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var ctx = new ByamlContext(openFileDialog1.FileName);
                
                fest = ctx.Deserialize<ByamlFestival>();

                updateControls();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = BYAML_FILTER;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var ctx = ByamlContext.FromObject(fest);

                BymlOptionForm form = new BymlOptionForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ctx.BOM = form.SelectedByteOrder;
                    ctx.ByamlVersion = form.SelectedVersion;

                    ctx.Write(saveFileDialog1.FileName);
                    SystemSounds.Asterisk.Play();
                }
                else SystemSounds.Hand.Play();
            }
        }

        private void updateControls()
        {
            updatingControl++;

            toolStripComboBox_Langs.Visible = true;
            tabControl1.Enabled = true;

            comboBox_newsType.Items.Clear();
            foreach (var item in fest.News)
                comboBox_newsType.Items.Add(item.ToString());

            listBox_actions.Items.Clear();
            comboBox_newsType.SelectedIndex = 0;
            comboBox_newsType_SelectedIndexChanged(null, null);

            textBox_alphaName.Text = fest.Teams[0].Name[GetCurrentLang()].Replace("\n", "\r\n");
            textBox_betaName.Text = fest.Teams[1].Name[GetCurrentLang()].Replace("\n", "\r\n");
            textBox_alphaShortName.Text = fest.Teams[0].ShortName[GetCurrentLang()].Replace("\n", "\r\n");
            textBox_betaShortName.Text = fest.Teams[1].ShortName[GetCurrentLang()].Replace("\n", "\r\n");
            pictureBox_alphaColor.BackColor = fest.Teams[0].GetColor();
            pictureBox_betaColor.BackColor = fest.Teams[1].GetColor();
            pictureBox_neutralColor.BackColor = fest.Teams[2].GetColor();

            textBox_announceTime.Text = fest.Time.Announce;
            textBox_startTime.Text = fest.Time.Start;
            textBox_endTime.Text = fest.Time.End;
            textBox_resultTime.Text = fest.Time.Result;
            value_festId.Value = fest.FestivalId;
            value_festVer.Value = fest.Version;

            updatingControl--;
        }

        private void comboBox_newsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatingControl++;

            textBox_actionText.Clear();
            listBox_actions.Items.Clear();

            int index = comboBox_newsType.SelectedIndex;
            if (index != -1)
            {
                listBox_actions.Enabled = true;
                var actions = fest.News[index].GetActions(GetCurrentLang());
                for (int i = 0; i < actions.Count; i++)
                    listBox_actions.Items.Add(i.ToString());

                if (actions.Count > 0)
                    listBox_actions.SelectedIndex = 0;

            }
            else listBox_actions.Enabled = false;

            updatingControl--;
        }

        private void listBox_actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatingControl++;
            var action = GetSelectedAction();
            if (action != null)
            {
                comboBox_speaker.SelectedIndex = Array.IndexOf(ByamlFestival.Speakers, action.Speaker);
                comboBox_emotion.SelectedIndex = Array.IndexOf(ByamlFestival.Emotions, action.Emotion);
                comboBox_cameraType.SelectedIndex = Array.IndexOf(ByamlFestival.CameraTypes, action.CameraType);
                checkBox_waitButton.Checked = action.WaitButton;

                textBox_actionText.Text = action.Text.Replace("\n", "\r\n");
            }
            updatingControl--;
        }

        private void toolStripComboBox_Langs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fest != null)
                updateControls();
        }

        private FestActionEntryObject GetSelectedAction()
        {
            int newsTypeIndex = comboBox_newsType.SelectedIndex;
            int index = listBox_actions.SelectedIndex;
            if (index != -1 && newsTypeIndex != -1)
            {
                return fest.News[newsTypeIndex].GetActions(GetCurrentLang())[index];
            }

            return null;
        }
        private string GetCurrentLang()
        {
            return (string)toolStripComboBox_Langs.SelectedItem;
        }

        //teams
        private void SaveTeams(object sender, EventArgs e)
        {
            fest.Teams[0].Name[GetCurrentLang()] = textBox_alphaName.Text.Replace("\r\n", "\n");
            fest.Teams[1].Name[GetCurrentLang()] = textBox_betaName.Text.Replace("\r\n", "\n");
            fest.Teams[0].ShortName[GetCurrentLang()] = textBox_alphaShortName.Text.Replace("\r\n", "\n");
            fest.Teams[1].ShortName[GetCurrentLang()] = textBox_betaShortName.Text.Replace("\r\n", "\n");
        }
        //colors
        private void pictureBox_alphaColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_alphaColor.BackColor = colorDialog1.Color;
                fest.Teams[0].SetColor(colorDialog1.Color);
            }
        }
        private void pictureBox_betaColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_betaColor.BackColor = colorDialog1.Color;
                fest.Teams[1].SetColor(colorDialog1.Color);
            }
        }
        private void pictureBox_neutralColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_neutralColor.BackColor = colorDialog1.Color;
                fest.Teams[2].SetColor(colorDialog1.Color);
            }
        }

        //other
        private void SaveOther(object sender, EventArgs e)
        {
            if (updatingControl > 0) return;

            fest.Time.Announce = textBox_announceTime.Text;
            fest.Time.Start = textBox_startTime.Text;
            fest.Time.End = textBox_endTime.Text;
            fest.Time.Result = textBox_resultTime.Text;
            fest.FestivalId = (int)value_festId.Value;
            fest.Version = (int)value_festVer.Value;
        }

        //news
        private void SaveScriptAction(object sender, EventArgs e)
        {
            if (updatingControl > 0) return;

            var action = GetSelectedAction();
            if (action != null)
            {
                action.Text = textBox_actionText.Text.Replace("\r\n", "\n");
                action.CameraType = (string)comboBox_cameraType.SelectedItem;
                action.Emotion = (string)comboBox_emotion.SelectedItem;
                action.Speaker = (string)comboBox_speaker.SelectedItem;
                action.WaitButton = checkBox_waitButton.Checked;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newsTypeIndex = comboBox_newsType.SelectedIndex;
            if (newsTypeIndex != -1)
            {
                fest.News[newsTypeIndex].GetActions(GetCurrentLang()).Add(new FestActionEntryObject());
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newsTypeIndex = comboBox_newsType.SelectedIndex;
            int index = listBox_actions.SelectedIndex;
            if (index != -1 && newsTypeIndex != -1)
            {
                fest.News[newsTypeIndex].GetActions(GetCurrentLang()).RemoveAt(index);
            }
        }

        private void listBox_actions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Items[1].Visible = listBox_actions.SelectedIndex != -1;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
