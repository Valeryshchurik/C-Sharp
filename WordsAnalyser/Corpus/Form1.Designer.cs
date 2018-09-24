using System;

namespace Corpus
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SerialisationSaveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ResultSaveButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.InputVocabularyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.DGGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AddTag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AGTag = new System.Windows.Forms.TextBox();
            this.AGWord = new System.Windows.Forms.TextBox();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddWord = new System.Windows.Forms.TextBox();
            this.AddGroup = new System.Windows.Forms.TextBox();
            this.AddWordButton = new System.Windows.Forms.Button();
            this.DelWord = new System.Windows.Forms.TextBox();
            this.DelGroup = new System.Windows.Forms.TextBox();
            this.DeleteWordButton = new System.Windows.Forms.Button();
            this.ShowgroupsButton = new System.Windows.Forms.Button();
            this.DictionaryGridView = new System.Windows.Forms.DataGridView();
            this.CanonicalWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllForms = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Frequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SerialisationSaveButton
            // 
            this.SerialisationSaveButton.Location = new System.Drawing.Point(721, 249);
            this.SerialisationSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SerialisationSaveButton.Name = "SerialisationSaveButton";
            this.SerialisationSaveButton.Size = new System.Drawing.Size(223, 47);
            this.SerialisationSaveButton.TabIndex = 2;
            this.SerialisationSaveButton.Text = "Выбрать файл для сохранения сериализации";
            this.SerialisationSaveButton.UseVisualStyleBackColor = true;
            this.SerialisationSaveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(722, 300);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 20);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(723, 371);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(222, 20);
            this.textBox3.TabIndex = 14;
            // 
            // ResultSaveButton
            // 
            this.ResultSaveButton.Location = new System.Drawing.Point(723, 321);
            this.ResultSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResultSaveButton.Name = "ResultSaveButton";
            this.ResultSaveButton.Size = new System.Drawing.Size(223, 47);
            this.ResultSaveButton.TabIndex = 13;
            this.ResultSaveButton.Text = "Выбрать файл для сохранения результата";
            this.ResultSaveButton.UseVisualStyleBackColor = true;
            this.ResultSaveButton.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(250, 24);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(248, 20);
            this.textBox4.TabIndex = 17;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // InputVocabularyButton
            // 
            this.InputVocabularyButton.Location = new System.Drawing.Point(10, 9);
            this.InputVocabularyButton.Margin = new System.Windows.Forms.Padding(2);
            this.InputVocabularyButton.Name = "InputVocabularyButton";
            this.InputVocabularyButton.Size = new System.Drawing.Size(220, 46);
            this.InputVocabularyButton.TabIndex = 18;
            this.InputVocabularyButton.Text = "Выбрать файл со словарём";
            this.InputVocabularyButton.UseVisualStyleBackColor = true;
            this.InputVocabularyButton.Click += new System.EventHandler(this.InputVocabularyButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(723, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 75);
            this.button1.TabIndex = 19;
            this.button1.Text = "Открыть окно для работы с текстами";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(26, 57);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(334, 20);
            this.textBox5.TabIndex = 21;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // DGGroup
            // 
            this.DGGroup.Location = new System.Drawing.Point(580, 449);
            this.DGGroup.Margin = new System.Windows.Forms.Padding(2);
            this.DGGroup.Name = "DGGroup";
            this.DGGroup.Size = new System.Drawing.Size(68, 20);
            this.DGGroup.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 451);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "канонич. слово";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(581, 469);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(67, 30);
            this.DeleteButton.TabIndex = 42;
            this.DeleteButton.Text = "удалить группу";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteGroupClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(533, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "тег";
            // 
            // AddTag
            // 
            this.AddTag.Location = new System.Drawing.Point(579, 264);
            this.AddTag.Margin = new System.Windows.Forms.Padding(2);
            this.AddTag.Name = "AddTag";
            this.AddTag.Size = new System.Drawing.Size(75, 20);
            this.AddTag.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 373);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "тег";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 354);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "слово";
            // 
            // AGTag
            // 
            this.AGTag.Location = new System.Drawing.Point(580, 373);
            this.AGTag.Margin = new System.Windows.Forms.Padding(2);
            this.AGTag.Name = "AGTag";
            this.AGTag.Size = new System.Drawing.Size(71, 20);
            this.AGTag.TabIndex = 37;
            // 
            // AGWord
            // 
            this.AGWord.Location = new System.Drawing.Point(580, 352);
            this.AGWord.Margin = new System.Windows.Forms.Padding(2);
            this.AGWord.Name = "AGWord";
            this.AGWord.Size = new System.Drawing.Size(71, 20);
            this.AGWord.TabIndex = 36;
            // 
            // AddGroupButton
            // 
            this.AddGroupButton.Location = new System.Drawing.Point(581, 393);
            this.AddGroupButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(69, 39);
            this.AddGroupButton.TabIndex = 35;
            this.AddGroupButton.Text = "добавить группу";
            this.AddGroupButton.UseVisualStyleBackColor = true;
            this.AddGroupButton.Click += new System.EventHandler(this.AddingTogroupClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "группа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "группа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "слово";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "слово";
            // 
            // AddWord
            // 
            this.AddWord.Location = new System.Drawing.Point(579, 286);
            this.AddWord.Margin = new System.Windows.Forms.Padding(2);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(75, 20);
            this.AddWord.TabIndex = 30;
            // 
            // AddGroup
            // 
            this.AddGroup.Location = new System.Drawing.Point(579, 243);
            this.AddGroup.Margin = new System.Windows.Forms.Padding(2);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(75, 20);
            this.AddGroup.TabIndex = 29;
            // 
            // AddWordButton
            // 
            this.AddWordButton.Location = new System.Drawing.Point(578, 307);
            this.AddWordButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddWordButton.Name = "AddWordButton";
            this.AddWordButton.Size = new System.Drawing.Size(75, 33);
            this.AddWordButton.TabIndex = 28;
            this.AddWordButton.Text = "добавить форму";
            this.AddWordButton.UseVisualStyleBackColor = true;
            // 
            // DelWord
            // 
            this.DelWord.Location = new System.Drawing.Point(578, 173);
            this.DelWord.Margin = new System.Windows.Forms.Padding(2);
            this.DelWord.Name = "DelWord";
            this.DelWord.Size = new System.Drawing.Size(74, 20);
            this.DelWord.TabIndex = 27;
            // 
            // DelGroup
            // 
            this.DelGroup.Location = new System.Drawing.Point(578, 152);
            this.DelGroup.Margin = new System.Windows.Forms.Padding(2);
            this.DelGroup.Name = "DelGroup";
            this.DelGroup.Size = new System.Drawing.Size(74, 20);
            this.DelGroup.TabIndex = 26;
            // 
            // DeleteWordButton
            // 
            this.DeleteWordButton.Location = new System.Drawing.Point(578, 194);
            this.DeleteWordButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteWordButton.Name = "DeleteWordButton";
            this.DeleteWordButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteWordButton.TabIndex = 25;
            this.DeleteWordButton.Text = "удалить форму";
            this.DeleteWordButton.UseVisualStyleBackColor = true;
            this.DeleteWordButton.Click += new System.EventHandler(this.DeleteWordClick);
            // 
            // ShowgroupsButton
            // 
            this.ShowgroupsButton.Location = new System.Drawing.Point(496, 113);
            this.ShowgroupsButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShowgroupsButton.Name = "ShowgroupsButton";
            this.ShowgroupsButton.Size = new System.Drawing.Size(195, 34);
            this.ShowgroupsButton.TabIndex = 24;
            this.ShowgroupsButton.Text = "Показать словарь групп";
            this.ShowgroupsButton.UseVisualStyleBackColor = true;
            this.ShowgroupsButton.Click += new System.EventHandler(this.ShowDictionaryClick);
            // 
            // DictionaryGridView
            // 
            this.DictionaryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DictionaryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CanonicalWord,
            this.AllForms,
            this.Frequence});
            this.DictionaryGridView.Location = new System.Drawing.Point(35, 113);
            this.DictionaryGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DictionaryGridView.Name = "DictionaryGridView";
            this.DictionaryGridView.RowTemplate.Height = 24;
            this.DictionaryGridView.Size = new System.Drawing.Size(428, 352);
            this.DictionaryGridView.TabIndex = 23;
            // 
            // CanonicalWord
            // 
            this.CanonicalWord.HeaderText = "CanonicalWord";
            this.CanonicalWord.Name = "CanonicalWord";
            // 
            // AllForms
            // 
            this.AllForms.HeaderText = "AllForms";
            this.AllForms.Name = "AllForms";
            this.AllForms.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllForms.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Frequence
            // 
            this.Frequence.HeaderText = "Frequence";
            this.Frequence.Name = "Frequence";
            this.Frequence.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(751, 119);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 87);
            this.button3.TabIndex = 45;
            this.button3.Text = "Открыть справку по тегам";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(1138, 594);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DGGroup);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddTag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AGTag);
            this.Controls.Add(this.AGWord);
            this.Controls.Add(this.AddGroupButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddWord);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.AddWordButton);
            this.Controls.Add(this.DelWord);
            this.Controls.Add(this.DelGroup);
            this.Controls.Add(this.DeleteWordButton);
            this.Controls.Add(this.ShowgroupsButton);
            this.Controls.Add(this.DictionaryGridView);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputVocabularyButton);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.ResultSaveButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.SerialisationSaveButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SerialisationSaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button ResultSaveButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button InputVocabularyButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox DGGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AddTag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AGTag;
        private System.Windows.Forms.TextBox AGWord;
        private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddWord;
        private System.Windows.Forms.TextBox AddGroup;
        private System.Windows.Forms.Button AddWordButton;
        private System.Windows.Forms.TextBox DelWord;
        private System.Windows.Forms.TextBox DelGroup;
        private System.Windows.Forms.Button DeleteWordButton;
        private System.Windows.Forms.Button ShowgroupsButton;
        private System.Windows.Forms.DataGridView DictionaryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanonicalWord;
        private System.Windows.Forms.DataGridViewComboBoxColumn AllForms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequence;
        private System.Windows.Forms.Button button3;
    }
}

