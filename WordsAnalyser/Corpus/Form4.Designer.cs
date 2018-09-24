namespace Corpus
{
    partial class Form4
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
            this.DictionaryGridView = new System.Windows.Forms.DataGridView();
            this.CanonicalWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllForms = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Frequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowgroupsButton = new System.Windows.Forms.Button();
            this.DeleteWordButton = new System.Windows.Forms.Button();
            this.DelGroup = new System.Windows.Forms.TextBox();
            this.DelWord = new System.Windows.Forms.TextBox();
            this.AddWordButton = new System.Windows.Forms.Button();
            this.AddGroup = new System.Windows.Forms.TextBox();
            this.AddWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.AGWord = new System.Windows.Forms.TextBox();
            this.AGTag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddTag = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.DGGroup = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DictionaryGridView
            // 
            this.DictionaryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DictionaryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CanonicalWord,
            this.AllForms,
            this.Frequence});
            this.DictionaryGridView.Location = new System.Drawing.Point(28, 14);
            this.DictionaryGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DictionaryGridView.Name = "DictionaryGridView";
            this.DictionaryGridView.RowTemplate.Height = 24;
            this.DictionaryGridView.Size = new System.Drawing.Size(428, 352);
            this.DictionaryGridView.TabIndex = 0;
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
            // ShowgroupsButton
            // 
            this.ShowgroupsButton.Location = new System.Drawing.Point(489, 14);
            this.ShowgroupsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShowgroupsButton.Name = "ShowgroupsButton";
            this.ShowgroupsButton.Size = new System.Drawing.Size(195, 34);
            this.ShowgroupsButton.TabIndex = 1;
            this.ShowgroupsButton.Text = "Показать словарь групп";
            this.ShowgroupsButton.UseVisualStyleBackColor = true;
            this.ShowgroupsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteWordButton
            // 
            this.DeleteWordButton.Location = new System.Drawing.Point(571, 95);
            this.DeleteWordButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteWordButton.Name = "DeleteWordButton";
            this.DeleteWordButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteWordButton.TabIndex = 2;
            this.DeleteWordButton.Text = "удалить форму";
            this.DeleteWordButton.UseVisualStyleBackColor = true;
            this.DeleteWordButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // DelGroup
            // 
            this.DelGroup.Location = new System.Drawing.Point(571, 53);
            this.DelGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DelGroup.Name = "DelGroup";
            this.DelGroup.Size = new System.Drawing.Size(74, 20);
            this.DelGroup.TabIndex = 3;
            // 
            // DelWord
            // 
            this.DelWord.Location = new System.Drawing.Point(571, 74);
            this.DelWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DelWord.Name = "DelWord";
            this.DelWord.Size = new System.Drawing.Size(74, 20);
            this.DelWord.TabIndex = 4;
            // 
            // AddWordButton
            // 
            this.AddWordButton.Location = new System.Drawing.Point(571, 208);
            this.AddWordButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddWordButton.Name = "AddWordButton";
            this.AddWordButton.Size = new System.Drawing.Size(75, 33);
            this.AddWordButton.TabIndex = 5;
            this.AddWordButton.Text = "добавить форму";
            this.AddWordButton.UseVisualStyleBackColor = true;
            this.AddWordButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddGroup
            // 
            this.AddGroup.Location = new System.Drawing.Point(572, 144);
            this.AddGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(75, 20);
            this.AddGroup.TabIndex = 6;
            // 
            // AddWord
            // 
            this.AddWord.Location = new System.Drawing.Point(572, 187);
            this.AddWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddWord.Name = "AddWord";
            this.AddWord.Size = new System.Drawing.Size(75, 20);
            this.AddWord.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "слово";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "слово";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "группа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "группа";
            // 
            // AddGroupButton
            // 
            this.AddGroupButton.Location = new System.Drawing.Point(574, 294);
            this.AddGroupButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(69, 39);
            this.AddGroupButton.TabIndex = 12;
            this.AddGroupButton.Text = "добавить группу";
            this.AddGroupButton.UseVisualStyleBackColor = true;
            this.AddGroupButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // AGWord
            // 
            this.AGWord.Location = new System.Drawing.Point(573, 253);
            this.AGWord.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AGWord.Name = "AGWord";
            this.AGWord.Size = new System.Drawing.Size(71, 20);
            this.AGWord.TabIndex = 13;
            // 
            // AGTag
            // 
            this.AGTag.Location = new System.Drawing.Point(573, 274);
            this.AGTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AGTag.Name = "AGTag";
            this.AGTag.Size = new System.Drawing.Size(71, 20);
            this.AGTag.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "слово";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 274);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "тег";
            // 
            // AddTag
            // 
            this.AddTag.Location = new System.Drawing.Point(572, 165);
            this.AddTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddTag.Name = "AddTag";
            this.AddTag.Size = new System.Drawing.Size(75, 20);
            this.AddTag.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 167);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "тег";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(574, 370);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(67, 30);
            this.DeleteButton.TabIndex = 19;
            this.DeleteButton.Text = "удалить группу";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(490, 352);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "канонич. слово";
            // 
            // DGGroup
            // 
            this.DGGroup.Location = new System.Drawing.Point(573, 350);
            this.DGGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGGroup.Name = "DGGroup";
            this.DGGroup.Size = new System.Drawing.Size(68, 20);
            this.DGGroup.TabIndex = 21;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 411);
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
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.DictionaryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DictionaryGridView;
        private System.Windows.Forms.Button ShowgroupsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanonicalWord;
        private System.Windows.Forms.DataGridViewComboBoxColumn AllForms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequence;
        private System.Windows.Forms.Button DeleteWordButton;
        private System.Windows.Forms.TextBox DelGroup;
        private System.Windows.Forms.TextBox DelWord;
        private System.Windows.Forms.Button AddWordButton;
        private System.Windows.Forms.TextBox AddGroup;
        private System.Windows.Forms.TextBox AddWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.TextBox AGWord;
        private System.Windows.Forms.TextBox AGTag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AddTag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DGGroup;
    }
}