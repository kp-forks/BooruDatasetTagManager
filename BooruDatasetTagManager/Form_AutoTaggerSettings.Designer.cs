﻿using System.Windows.Forms;

namespace BooruDatasetTagManager
{
    partial class Form_AutoTaggerSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            comboBoxSortMode = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            checkedListBoxcomboBoxInterrogators = new CheckedListBox();
            label4 = new Label();
            comboBoxUnionMode = new ComboBox();
            checkBoxSerializeVRAM = new CheckBox();
            checkBoxSkipInternet = new CheckBox();
            label5 = new Label();
            comboBoxSetMode = new ComboBox();
            comboBoxTagFilterMode = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            textBoxTagFilter = new TextBox();
            TaggerSettingTabs = new Manina.Windows.Forms.TabControl();
            tabGeneral = new Manina.Windows.Forms.Tab();
            label3 = new Label();
            linkLabelRepo = new LinkLabel();
            labelRepo = new Label();
            checkBoxSupportVideo = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            pictureBox1 = new PictureBox();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            TaggerSettingTabs.SuspendLayout();
            tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Interrogator";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Sort mode";
            // 
            // comboBoxSortMode
            // 
            comboBoxSortMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortMode.FormattingEnabled = true;
            comboBoxSortMode.Location = new System.Drawing.Point(12, 118);
            comboBoxSortMode.Name = "comboBoxSortMode";
            comboBoxSortMode.Size = new System.Drawing.Size(393, 23);
            comboBoxSortMode.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.CausesValidation = false;
            button1.Location = new System.Drawing.Point(12, 548);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.CausesValidation = false;
            button2.Location = new System.Drawing.Point(93, 548);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkedListBoxcomboBoxInterrogators
            // 
            checkedListBoxcomboBoxInterrogators.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBoxcomboBoxInterrogators.CheckOnClick = true;
            checkedListBoxcomboBoxInterrogators.FormattingEnabled = true;
            checkedListBoxcomboBoxInterrogators.Location = new System.Drawing.Point(12, 27);
            checkedListBoxcomboBoxInterrogators.Name = "checkedListBoxcomboBoxInterrogators";
            checkedListBoxcomboBoxInterrogators.ScrollAlwaysVisible = true;
            checkedListBoxcomboBoxInterrogators.Size = new System.Drawing.Size(440, 508);
            checkedListBoxcomboBoxInterrogators.TabIndex = 7;
            checkedListBoxcomboBoxInterrogators.ItemCheck += checkedListBoxcomboBoxInterrogators_ItemCheck;
            checkedListBoxcomboBoxInterrogators.SelectedIndexChanged += checkedListBoxcomboBoxInterrogators_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 56);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(264, 15);
            label4.TabIndex = 0;
            label4.Text = "Mode for merging results with multiple selection";
            // 
            // comboBoxUnionMode
            // 
            comboBoxUnionMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnionMode.FormattingEnabled = true;
            comboBoxUnionMode.Location = new System.Drawing.Point(12, 74);
            comboBoxUnionMode.Name = "comboBoxUnionMode";
            comboBoxUnionMode.Size = new System.Drawing.Size(393, 23);
            comboBoxUnionMode.TabIndex = 1;
            // 
            // checkBoxSerializeVRAM
            // 
            checkBoxSerializeVRAM.AutoSize = true;
            checkBoxSerializeVRAM.Location = new System.Drawing.Point(12, 244);
            checkBoxSerializeVRAM.Name = "checkBoxSerializeVRAM";
            checkBoxSerializeVRAM.Size = new System.Drawing.Size(138, 19);
            checkBoxSerializeVRAM.TabIndex = 8;
            checkBoxSerializeVRAM.Text = "Serialize VRAM usage";
            checkBoxSerializeVRAM.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipInternet
            // 
            checkBoxSkipInternet.AutoSize = true;
            checkBoxSkipInternet.Location = new System.Drawing.Point(12, 269);
            checkBoxSkipInternet.Name = "checkBoxSkipInternet";
            checkBoxSkipInternet.Size = new System.Drawing.Size(139, 19);
            checkBoxSkipInternet.TabIndex = 8;
            checkBoxSkipInternet.Text = "Skip internet requests";
            checkBoxSkipInternet.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 10);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(112, 15);
            label5.TabIndex = 0;
            label5.Text = "Result output mode";
            // 
            // comboBoxSetMode
            // 
            comboBoxSetMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSetMode.FormattingEnabled = true;
            comboBoxSetMode.Location = new System.Drawing.Point(12, 28);
            comboBoxSetMode.Name = "comboBoxSetMode";
            comboBoxSetMode.Size = new System.Drawing.Size(393, 23);
            comboBoxSetMode.TabIndex = 1;
            // 
            // comboBoxTagFilterMode
            // 
            comboBoxTagFilterMode.CausesValidation = false;
            comboBoxTagFilterMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTagFilterMode.FormattingEnabled = true;
            comboBoxTagFilterMode.Location = new System.Drawing.Point(12, 162);
            comboBoxTagFilterMode.Name = "comboBoxTagFilterMode";
            comboBoxTagFilterMode.Size = new System.Drawing.Size(393, 23);
            comboBoxTagFilterMode.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 144);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(84, 15);
            label6.TabIndex = 9;
            label6.Text = "Filtering mode";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 188);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 15);
            label7.TabIndex = 12;
            label7.Text = "Tag Filter";
            // 
            // textBoxTagFilter
            // 
            textBoxTagFilter.Location = new System.Drawing.Point(12, 206);
            textBoxTagFilter.Name = "textBoxTagFilter";
            textBoxTagFilter.Size = new System.Drawing.Size(393, 23);
            textBoxTagFilter.TabIndex = 13;
            textBoxTagFilter.Validating += textBoxTagFilter_Validating;
            // 
            // TaggerSettingTabs
            // 
            TaggerSettingTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TaggerSettingTabs.Controls.Add(tabGeneral);
            TaggerSettingTabs.Location = new System.Drawing.Point(457, 27);
            TaggerSettingTabs.Name = "TaggerSettingTabs";
            TaggerSettingTabs.SelectedIndex = 0;
            TaggerSettingTabs.Size = new System.Drawing.Size(445, 508);
            TaggerSettingTabs.TabIndex = 6;
            TaggerSettingTabs.Tabs.Add(tabGeneral);
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(label3);
            tabGeneral.Controls.Add(linkLabelRepo);
            tabGeneral.Controls.Add(labelRepo);
            tabGeneral.Controls.Add(label5);
            tabGeneral.Controls.Add(checkBoxSupportVideo);
            tabGeneral.Controls.Add(checkBoxSkipInternet);
            tabGeneral.Controls.Add(textBoxTagFilter);
            tabGeneral.Controls.Add(checkBoxSerializeVRAM);
            tabGeneral.Controls.Add(label2);
            tabGeneral.Controls.Add(label7);
            tabGeneral.Controls.Add(label4);
            tabGeneral.Controls.Add(comboBoxTagFilterMode);
            tabGeneral.Controls.Add(comboBoxSortMode);
            tabGeneral.Controls.Add(label6);
            tabGeneral.Controls.Add(comboBoxUnionMode);
            tabGeneral.Controls.Add(comboBoxSetMode);
            tabGeneral.Location = new System.Drawing.Point(1, 23);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Size = new System.Drawing.Size(443, 484);
            tabGeneral.Text = "General";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 323);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(154, 15);
            label3.TabIndex = 14;
            label3.Text = "Selected model information";
            // 
            // linkLabelRepo
            // 
            linkLabelRepo.AutoEllipsis = true;
            linkLabelRepo.AutoSize = true;
            linkLabelRepo.Location = new System.Drawing.Point(17, 378);
            linkLabelRepo.Name = "linkLabelRepo";
            linkLabelRepo.Size = new System.Drawing.Size(12, 15);
            linkLabelRepo.TabIndex = 2;
            linkLabelRepo.TabStop = true;
            linkLabelRepo.Text = "-";
            linkLabelRepo.LinkClicked += linkLabelRepo_LinkClicked;
            // 
            // labelRepo
            // 
            labelRepo.AutoSize = true;
            labelRepo.Location = new System.Drawing.Point(17, 363);
            labelRepo.Name = "labelRepo";
            labelRepo.Size = new System.Drawing.Size(88, 15);
            labelRepo.TabIndex = 1;
            labelRepo.Text = "Repository link:";
            // 
            // checkBoxSupportVideo
            // 
            checkBoxSupportVideo.AutoCheck = false;
            checkBoxSupportVideo.AutoSize = true;
            checkBoxSupportVideo.Location = new System.Drawing.Point(17, 341);
            checkBoxSupportVideo.Name = "checkBoxSupportVideo";
            checkBoxSupportVideo.Size = new System.Drawing.Size(149, 19);
            checkBoxSupportVideo.TabIndex = 0;
            checkBoxSupportVideo.Text = "Supports video analysis";
            checkBoxSupportVideo.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Green;
            pictureBox1.Location = new System.Drawing.Point(218, 549);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(18, 22);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(239, 552);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(101, 15);
            label8.TabIndex = 9;
            label8.Text = "- supported video";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Crimson;
            pictureBox2.Location = new System.Drawing.Point(365, 549);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(18, 22);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(386, 552);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(122, 15);
            label9.TabIndex = 9;
            label9.Text = "- not supported video";
            // 
            // Form_AutoTaggerSettings
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new System.Drawing.Size(916, 585);
            Controls.Add(label9);
            Controls.Add(pictureBox2);
            Controls.Add(label8);
            Controls.Add(pictureBox1);
            Controls.Add(TaggerSettingTabs);
            Controls.Add(checkedListBoxcomboBoxInterrogators);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form_AutoTaggerSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auto tagger settings";
            FormClosing += Form_AutoTaggerSettings_FormClosing;
            Load += Form_AutoTaggerSettings_Load;
            TaggerSettingTabs.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSortMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBoxcomboBoxInterrogators;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxUnionMode;
        private System.Windows.Forms.CheckBox checkBoxSerializeVRAM;
        private System.Windows.Forms.CheckBox checkBoxSkipInternet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSetMode;
        private System.Windows.Forms.ComboBox comboBoxTagFilterMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTagFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Manina.Windows.Forms.TabControl TaggerSettingTabs;
        private Manina.Windows.Forms.Tab tabGeneral;
        private LinkLabel linkLabelRepo;
        private Label labelRepo;
        private CheckBox checkBoxSupportVideo;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label9;
        private PictureBox pictureBox2;
        private Label label8;
    }
}