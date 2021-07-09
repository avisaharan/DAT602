
namespace SnakeAndLadders
{
    partial class CreateNewGame
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
            this.label2 = new System.Windows.Forms.Label();
            this.gameNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createGameButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Game";
            // 
            // gameNameBox
            // 
            this.gameNameBox.Location = new System.Drawing.Point(415, 129);
            this.gameNameBox.Name = "gameNameBox";
            this.gameNameBox.Size = new System.Drawing.Size(100, 20);
            this.gameNameBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Name";
            // 
            // createGameButton
            // 
            this.createGameButton.Location = new System.Drawing.Point(361, 185);
            this.createGameButton.Name = "createGameButton";
            this.createGameButton.Size = new System.Drawing.Size(75, 23);
            this.createGameButton.TabIndex = 5;
            this.createGameButton.Text = "Create";
            this.createGameButton.UseVisualStyleBackColor = true;
            this.createGameButton.Click += new System.EventHandler(this.createGameButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(361, 214);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CreateNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameNameBox);
            this.Controls.Add(this.label2);
            this.Name = "CreateNewGame";
            this.Text = "CreateNewGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gameNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createGameButton;
        private System.Windows.Forms.Button cancelButton;
    }
}