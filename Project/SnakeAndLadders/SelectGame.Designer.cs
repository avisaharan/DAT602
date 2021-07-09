
namespace SnakeAndLadders
{
    partial class SelectGame
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
            this.CurrentlyActiveGamesList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PlayersInTheSelectedGame = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "List of Active Games";
            // 
            // CurrentlyActiveGamesList
            // 
            this.CurrentlyActiveGamesList.FormattingEnabled = true;
            this.CurrentlyActiveGamesList.Location = new System.Drawing.Point(306, 98);
            this.CurrentlyActiveGamesList.Name = "CurrentlyActiveGamesList";
            this.CurrentlyActiveGamesList.Size = new System.Drawing.Size(161, 212);
            this.CurrentlyActiveGamesList.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create New Game";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Join This Game";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PlayersInTheSelectedGame
            // 
            this.PlayersInTheSelectedGame.FormattingEnabled = true;
            this.PlayersInTheSelectedGame.Location = new System.Drawing.Point(516, 98);
            this.PlayersInTheSelectedGame.Name = "PlayersInTheSelectedGame";
            this.PlayersInTheSelectedGame.Size = new System.Drawing.Size(161, 212);
            this.PlayersInTheSelectedGame.TabIndex = 5;
            // 
            // SelectGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayersInTheSelectedGame);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrentlyActiveGamesList);
            this.Controls.Add(this.label2);
            this.Name = "SelectGame";
            this.Text = "Select Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox CurrentlyActiveGamesList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox PlayersInTheSelectedGame;
    }
}