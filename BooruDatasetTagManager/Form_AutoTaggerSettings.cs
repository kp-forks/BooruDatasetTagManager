﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manina.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace BooruDatasetTagManager
{
    public partial class Form_AutoTaggerSettings : Form
    {
        private Dictionary<string, Control> interrogatorSettingsControls = new Dictionary<string, Control>();
        private List<string> selectedInterrogators = new List<string>();
        private string ctrlPattern = "(.*?)_ctrl_(.*)";
        public Form_AutoTaggerSettings()
        {
            InitializeComponent();
            comboBoxSortMode.Items.AddRange(Extensions.GetFriendlyEnumValues<AutoTaggerSort>());
            comboBoxUnionMode.Items.AddRange(Extensions.GetFriendlyEnumValues<NetworkUnionMode>());
            comboBoxSetMode.Items.AddRange(Extensions.GetFriendlyEnumValues<NetworkResultSetMode>());
            comboBoxTagFilterMode.Items.AddRange(Extensions.GetFriendlyEnumValues<TagFilteringMode>());
            Program.ColorManager.ChangeColorScheme(this, Program.ColorManager.SelectedScheme);
            Program.ColorManager.ChangeColorSchemeInConteiner(Controls, Program.ColorManager.SelectedScheme);
            connectRechecker = new Timer();
            connectRechecker.Tick += ConnectRechecker_Tick;
            connectRechecker.Interval = 5000;
            SwitchLanguage();
        }

        private async void ConnectRechecker_Tick(object sender, EventArgs e)
        {
            if (await Program.AutoTagger.ConnectAsync())
            {
                if (Controls.ContainsKey("errorLabel"))
                {
                    Controls.RemoveByKey("errorLabel");
                }
                connectRechecker.Stop();
                Form_AutoTaggerSettings_Load(sender, e);
            }
        }

        private Timer connectRechecker;

        private async void Form_AutoTaggerSettings_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (!Program.AutoTagger.IsConnected)
            {

                if (!await Program.AutoTagger.ConnectAsync())
                {
                    Label errLabel = new Label();
                    errLabel.Name = "errorLabel";
                    errLabel.Text = I18n.GetText("TipAutoTagUnableConnect");
                    errLabel.Location = checkedListBoxcomboBoxInterrogators.Location;
                    errLabel.Size = checkedListBoxcomboBoxInterrogators.Size;
                    errLabel.Font = new Font("Segoe UI", 12);
                    errLabel.ForeColor = Color.Red;
                    Controls.Add(errLabel);
                    errLabel.BringToFront();
                    connectRechecker.Start();
                }
            }
            if (Program.AutoTagger.IsConnected)
            {
                checkedListBoxcomboBoxInterrogators.Items.AddRange(Program.AutoTagger.Config.Interrogators.ToArray());
                button1.Enabled = true;
                foreach (var item in Program.Settings.AutoTagger.InterragatorParams)
                {
                    int index = checkedListBoxcomboBoxInterrogators.Items.IndexOf(item.Key);
                    if (index != -1)
                    {
                        checkedListBoxcomboBoxInterrogators.SetItemChecked(index, true);
                    }
                }
                comboBoxSortMode.SelectedIndex = Extensions.GetEnumIndexFromValue<AutoTaggerSort>(Program.Settings.AutoTagger.SortMode.ToString());
                comboBoxUnionMode.SelectedIndex = Extensions.GetEnumIndexFromValue<NetworkUnionMode>(Program.Settings.AutoTagger.UnionMode.ToString());
                comboBoxSetMode.SelectedIndex = Extensions.GetEnumIndexFromValue<NetworkResultSetMode>(Program.Settings.AutoTagger.SetMode.ToString());
                comboBoxTagFilterMode.SelectedIndex = Extensions.GetEnumIndexFromValue<TagFilteringMode>(Program.Settings.AutoTagger.TagFilteringMode.ToString());
                textBoxTagFilter.Text = Program.Settings.AutoTagger.TagFilter;
                checkBoxSerializeVRAM.Checked = Program.Settings.AutoTagger.SerializeVramUsage;
                checkBoxSkipInternet.Checked = Program.Settings.AutoTagger.SkipInternetRequests;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.AutoTagger.InterragatorParams.Clear();
            //for (int i = 0; i < checkedListBoxcomboBoxInterrogators.CheckedItems.Count; i++)
            //{
            //    //NEED FIX
            //   // Program.Settings.AutoTagger.InterragatorParams.Add(new KeyValuePair<string, float>((string)checkedListBoxcomboBoxInterrogators.CheckedItems[i], threshold));
            //}
            SaveSettingsFromControls();
            Program.Settings.AutoTagger.SortMode = Extensions.GetEnumItemFromFriendlyText<AutoTaggerSort>(comboBoxSortMode.SelectedItem.ToString());
            Program.Settings.AutoTagger.UnionMode = Extensions.GetEnumItemFromFriendlyText<NetworkUnionMode>(comboBoxUnionMode.SelectedItem.ToString());
            Program.Settings.AutoTagger.SetMode = Extensions.GetEnumItemFromFriendlyText<NetworkResultSetMode>(comboBoxSetMode.SelectedItem.ToString());
            Program.Settings.AutoTagger.TagFilteringMode = Extensions.GetEnumItemFromFriendlyText<TagFilteringMode>(comboBoxTagFilterMode.SelectedItem.ToString());
            Program.Settings.AutoTagger.TagFilter = textBoxTagFilter.Text;
            Program.Settings.AutoTagger.SerializeVramUsage = checkBoxSerializeVRAM.Checked;
            Program.Settings.AutoTagger.SkipInternetRequests = checkBoxSkipInternet.Checked;
            if (ValidateChildren())
            {
                Program.Settings.SaveSettings();
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form_AutoTaggerSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectRechecker.Enabled)
                connectRechecker.Stop();
            if (Controls.ContainsKey("errorLabel"))
            {
                Controls.RemoveByKey("errorLabel");
            }
        }

        private void SwitchLanguage()
        {
            this.Text = I18n.GetText("UIAutoTagForm");
            label1.Text = I18n.GetText("UIAutoTagInterrogatorLabel");
            label5.Text = I18n.GetText("UIAutoTagResultOutputMode");
            label4.Text = I18n.GetText("UIAutoTagModeMerging");
            label2.Text = I18n.GetText("UIAutoTagSortMode");
            label6.Text = I18n.GetText("UIAutoTagFilteringMode");
            label7.Text = I18n.GetText("UIAutoTagFilter");
            checkBoxSerializeVRAM.Text = I18n.GetText("UIAutoTagSerializeVram");
            checkBoxSkipInternet.Text = I18n.GetText("UIAutoTagSkipInternetReq");
        }

        private void textBoxTagFilter_Validating(object sender, CancelEventArgs e)
        {
            Label label = label7;
            RemoveError(label, e);
            TagFilteringMode tagFilteringMode = Extensions.GetEnumItemFromFriendlyText<TagFilteringMode>(comboBoxTagFilterMode.SelectedItem.ToString());
            if (tagFilteringMode != TagFilteringMode.None && string.IsNullOrEmpty(textBoxTagFilter.Text))
            {
                DisplayError(label, I18n.GetText("Required"), e);
            }
            if (tagFilteringMode == TagFilteringMode.Regex)
            {
                try
                {
                    Regex.IsMatch("", textBoxTagFilter.Text);
                }
                catch
                {
                    DisplayError(label, I18n.GetText("TipInvalidRegex"), e);
                }
            }
        }

        private void DisplayError(Label label, string message, CancelEventArgs e)
        {
            Label errLabel = new Label();
            errLabel.Name = label.Name + "Error";
            errLabel.Text = message;
            errLabel.Location = new Point(label.Location.X + label.Width + 16, label.Location.Y);
            errLabel.AutoSize = true;
            errLabel.Font = new Font("Segoe UI", 9);
            errLabel.ForeColor = Color.Red;
            Controls.Add(errLabel);
            errLabel.BringToFront();
            errorProvider1.SetError(label, I18n.GetText("TipInvalidValue"));
            e.Cancel = true;
        }

        private void RemoveError(Label label, CancelEventArgs e)
        {
            string key = label.Name + "Error";
            if (Controls.ContainsKey(key))
            {
                Controls.RemoveByKey(key);
            }
            errorProvider1.SetError(label, string.Empty);
            e.Cancel = false;
        }

        private async void checkedListBoxcomboBoxInterrogators_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                if (!await CreateInterrogatorTabAsync(checkedListBoxcomboBoxInterrogators.Items[e.Index].ToString()))
                {
                    e.NewValue = CheckState.Unchecked;
                    return;
                }
                SetSavedSettingsToControls();
            }
            else if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                RemoveTab(checkedListBoxcomboBoxInterrogators.Items[e.Index].ToString());
            }
        }

        private async Task<bool> CreateInterrogatorTabAsync(string name)
        {
            var intParams = await Program.AutoTagger.GetModelParams(name);
            if (!intParams.Success)
            {
                MessageBox.Show(intParams.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            selectedInterrogators.Add(name);
            Tab tab = new Tab();
            tab.Name = name;
            tab.Text = name;
            TableLayoutPanel panel = new TableLayoutPanel();
            TaggerSettingTabs.Tabs.Add(tab);
            TaggerSettingTabs.SuspendLayout();
            panel.ColumnCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            panel.Padding = new Padding(10);
            tab.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            foreach (var item in intParams.Parameters)
            {
                panel.RowCount++;
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 23f));
                Label lbl = new Label();
                lbl.Padding = new Padding(0,6,0,2);
                lbl.Name = name + "_lbl_" + item.Key.Replace(" ", "");
                lbl.Text = item.Key.ToUpper() + ":";
                lbl.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                panel.Controls.Add(lbl, 0, panel.RowCount - 1);
                lbl.Dock = DockStyle.Fill;
                lbl.AutoSize = true;
                if (item.Type == "float1")
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
                    TrackBar bar = new TrackBar();
                    bar.Name = name + "_ctrl_" + item.Key.Replace(" ", "");
                    bar.Minimum = 0;
                    bar.Maximum = 100;
                    bar.SmallChange = 1;
                    bar.ValueChanged += new EventHandler(delegate (object sender, EventArgs e)
                    {
                        lbl.Text = item.Key + ": " + (float)bar.Value / 100f;
                    });
                    panel.Controls.Add(bar, 0, panel.RowCount - 1);
                    bar.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    bar.Value = (int)(Convert.ToSingle(item.Value, CultureInfo.InvariantCulture.NumberFormat) * 100);
                    interrogatorSettingsControls.Add(bar.Name, bar);
                }
                else if (item.Type == "string")
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
                    TextBox textBox = new TextBox();
                    textBox.Name = name + "_ctrl_" + item.Key.Replace(" ", "");
                    panel.Controls.Add(textBox, 0, panel.RowCount - 1);
                    textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    textBox.Text = item.Value;
                    interrogatorSettingsControls.Add(textBox.Name, textBox);
                }
                else if (item.Type == "label")
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 25f));
                    Label lb = new Label();
                    lb.Name = name + "_ctrl_" + item.Key.Replace(" ", "");
                    panel.Controls.Add(lb, 0, panel.RowCount - 1);
                    lb.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    lb.Dock = DockStyle.Fill;
                    lb.AutoSize = true;
                    lb.Text = item.Value;
                    interrogatorSettingsControls.Add(lb.Name, lb);
                }
                else if (item.Type == "bool")
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = name + "_ctrl_" + item.Key.Replace(" ", "");
                    panel.Controls.Add(checkBox, 0, panel.RowCount - 1);
                    checkBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    checkBox.Text = item.Comment;
                    checkBox.Checked = bool.Parse(item.Value);
                    interrogatorSettingsControls.Add(checkBox.Name, checkBox);
                }
                else if (item.Type == "list")
                {
                    panel.RowCount++;
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
                    ComboBox cbList = new ComboBox();
                    cbList.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbList.Items.AddRange(item.Value.Split(','));
                    cbList.Name = name + "_ctrl_" + item.Key.Replace(" ", "");
                    panel.Controls.Add(cbList, 0, panel.RowCount - 1);
                    cbList.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    interrogatorSettingsControls.Add(cbList.Name, cbList);
                    if (cbList.Items.Count > 0)
                        cbList.SelectedIndex = 0;
                }

            }
            Program.ColorManager.ChangeColorScheme(tab, Program.ColorManager.SelectedScheme);
            Program.ColorManager.ChangeColorSchemeInConteiner(tab.Controls, Program.ColorManager.SelectedScheme);
            TaggerSettingTabs.ResumeLayout();
            return true;
        }

        private void RemoveTab(string name)
        {
            var tab = TaggerSettingTabs.Tabs.FirstOrDefault(a=>a.Name == name);
            if (tab != null)
            {
                TaggerSettingTabs.Tabs.Remove(tab);
            }
            selectedInterrogators.Remove(name);
            var ctrlsToRemove = interrogatorSettingsControls.Where(a => a.Key.StartsWith(name + "_ctrl")).Select(a => a.Key);
            foreach(var item in ctrlsToRemove)
                interrogatorSettingsControls.Remove(item);
        }

        private void SetSavedSettingsToControls()
        {
            if (Program.Settings.AutoTagger.InterragatorParams.Count == 0)
                return;
            foreach (var inter in Program.Settings.AutoTagger.InterragatorParams)
            {
                foreach (var item in inter.Value) {
                    string ctrlName = inter.Key + "_ctrl_" + item.Key;
                    if (interrogatorSettingsControls.ContainsKey(ctrlName))
                    {
                        Control ctrl = interrogatorSettingsControls[ctrlName];
                        if (ctrl.GetType() == typeof(TrackBar))
                        {
                            TrackBar trBar = (TrackBar)ctrl;
                            trBar.Value = (int)(Convert.ToSingle(item.Value, CultureInfo.InvariantCulture.NumberFormat) * 100);
                        }
                        else if (ctrl.GetType() == typeof(TextBox))
                        {
                            TextBox tb = (TextBox)ctrl;
                            tb.Text = item.Value;
                        }
                        else if (ctrl.GetType() == typeof(CheckBox))
                        {
                            CheckBox cb = (CheckBox)ctrl;
                            cb.Checked = bool.Parse(item.Value);
                        }
                        else if (ctrl.GetType() == typeof(ComboBox))
                        {
                            ComboBox cb = (ComboBox)ctrl;
                            cb.SelectedItem = item.Value;
                        }
                    }
                }
            }
        }

        private void SaveSettingsFromControls()
        {
            Program.Settings.AutoTagger.InterragatorParams.Clear();

            foreach (var network in selectedInterrogators)
            {
                if (!Program.Settings.AutoTagger.InterragatorParams.ContainsKey(network))
                {
                    Program.Settings.AutoTagger.InterragatorParams.Add(network, new List<AdditionalParameters>());
                }
            }

            foreach (var item in interrogatorSettingsControls)
            {
                Regex r = new Regex(ctrlPattern, RegexOptions.Compiled);
                Match match = r.Match(item.Key);
                if (!match.Success)
                    throw new Exception("Unable to recognize pattern! Bad implementation?");
                string network = match.Groups[1].Value;
                AdditionalParameters addParams = new AdditionalParameters();
                addParams.Key = match.Groups[2].Value;
                Control ctrl = item.Value;
                if (ctrl.GetType() == typeof(TrackBar))
                {
                    TrackBar trBar = (TrackBar)ctrl;
                    addParams.Type = "float1";
                    addParams.Value = ((float)trBar.Value / 100f).ToString(CultureInfo.InvariantCulture.NumberFormat);
                }
                else if (ctrl.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)ctrl;
                    addParams.Type = "string";
                    addParams.Value = tb.Text;
                }
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = (CheckBox)ctrl;
                    addParams.Type = "bool";
                    addParams.Value = cb.Checked.ToString().ToLower();
                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)ctrl;
                    addParams.Type = "list";
                    addParams.Value = cb.SelectedItem.ToString();
                }
                else if (ctrl.GetType() == typeof(Label))
                {
                    continue;
                }
                if (Program.Settings.AutoTagger.InterragatorParams.ContainsKey(network))
                {
                    Program.Settings.AutoTagger.InterragatorParams[network].Add(addParams);
                }
                else
                {
                    Program.Settings.AutoTagger.InterragatorParams.Add(network, new List<AdditionalParameters> { addParams });
                }
            }
        }
    }
}
