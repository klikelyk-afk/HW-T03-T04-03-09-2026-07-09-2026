using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HW_T03_T04_03_09_2026_07_09_2026
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new Button();
            deleteButton = new Button();
            documentButton = new Button();
            animalGridView = new DataGridView();
            vaccinationStatusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)animalGridView).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(664, 307);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(87, 20);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            deleteButton.Location = new Point(582, 307);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(76, 20);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // documentButton
            // 
            documentButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            documentButton.Location = new Point(494, 307);
            documentButton.Margin = new Padding(3, 2, 3, 2);
            documentButton.Name = "documentButton";
            documentButton.Size = new Size(82, 20);
            documentButton.TabIndex = 2;
            documentButton.Text = "Document";
            documentButton.UseVisualStyleBackColor = true;
            documentButton.Click += documentButton_Click;
            // 
            // animalGridView
            // 
            animalGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            animalGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            animalGridView.BackgroundColor = SystemColors.ControlLightLight;
            animalGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            animalGridView.Location = new Point(10, 9);
            animalGridView.Margin = new Padding(3, 2, 3, 2);
            animalGridView.Name = "animalGridView";
            animalGridView.RowHeadersWidth = 51;
            animalGridView.Size = new Size(745, 289);
            animalGridView.TabIndex = 3;
            animalGridView.CellContentClick += animalGridView_CellContentClick;
            // 
            // vaccinationStatusLabel
            // 
            vaccinationStatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            vaccinationStatusLabel.AutoSize = true;
            vaccinationStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            vaccinationStatusLabel.Location = new Point(10, 308);
            vaccinationStatusLabel.Name = "vaccinationStatusLabel";
            vaccinationStatusLabel.Size = new Size(145, 19);
            vaccinationStatusLabel.TabIndex = 4;
            vaccinationStatusLabel.Text = "Статус вакцинації...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 345);
            Controls.Add(vaccinationStatusLabel);
            Controls.Add(animalGridView);
            Controls.Add(documentButton);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)animalGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Button deleteButton;
        private Button documentButton;
        private DataGridView animalGridView;
        private Label vaccinationStatusLabel;
    }
}