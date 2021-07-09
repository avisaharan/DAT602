
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PlayersInTheSelectedGame = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.adminToolsButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 73);
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
            this.CurrentlyActiveGamesList.SelectedIndexChanged += new System.EventHandler(this.CurrentlyActiveGamesList_SelectedIndexChanged);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(323, 379);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(132, 23);
            this.newGameButton.TabIndex = 3;
            this.newGameButton.Text = "Create New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(298, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(298, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(491, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(281, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(512, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Players in the Game";
            // 
            // adminToolsButton
            // 
            this.adminToolsButton.Location = new System.Drawing.Point(546, 358);
            this.adminToolsButton.Name = "adminToolsButton";
            this.adminToolsButton.Size = new System.Drawing.Size(102, 23);
            this.adminToolsButton.TabIndex = 13;
            this.adminToolsButton.Text = "Admin Panel";
            this.adminToolsButton.UseVisualStyleBackColor = true;
            this.adminToolsButton.Click += new System.EventHandler(this.adminToolsButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(512, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "3";
            // 
            // SelectGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.adminToolsButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PlayersInTheSelectedGame);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.CurrentlyActiveGamesList);
            this.Controls.Add(this.label2);
            this.Name = "SelectGame";
            this.Text = "Select Game";
            this.Load += new System.EventHandler(this.SelectGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox CurrentlyActiveGamesList;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox PlayersInTheSelectedGame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button adminToolsButton;
        private System.Windows.Forms.Label label8;
    }
}