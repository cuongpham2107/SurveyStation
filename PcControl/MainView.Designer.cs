namespace PcControl {
    partial class MainView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tabManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonActiveStations = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.ribbonCapturedImages = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStationList = new DevExpress.XtraBars.BarListItem();
            this.ribbonConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabManager
            // 
            this.tabManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.tabManager.MdiParent = this;
            this.tabManager.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.ribbonActiveStations,
            this.ribbonCapturedImages,
            this.ribbonStationList,
            this.ribbonConfiguration});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.Size = new System.Drawing.Size(778, 126);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonActiveStations
            // 
            this.ribbonActiveStations.Caption = "Active Stations";
            this.ribbonActiveStations.Id = 1;
            this.ribbonActiveStations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonActiveStations.ImageOptions.Image")));
            this.ribbonActiveStations.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonActiveStations.ImageOptions.LargeImage")));
            this.ribbonActiveStations.Name = "ribbonActiveStations";
            // 
            // ribbonCapturedImages
            // 
            this.ribbonCapturedImages.Caption = "Captured Images";
            this.ribbonCapturedImages.Id = 3;
            this.ribbonCapturedImages.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonCapturedImages.ImageOptions.Image")));
            this.ribbonCapturedImages.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonCapturedImages.ImageOptions.LargeImage")));
            this.ribbonCapturedImages.Name = "ribbonCapturedImages";
            // 
            // ribbonStationList
            // 
            this.ribbonStationList.Caption = "Stations";
            this.ribbonStationList.Id = 4;
            this.ribbonStationList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonStationList.ImageOptions.Image")));
            this.ribbonStationList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonStationList.ImageOptions.LargeImage")));
            this.ribbonStationList.Name = "ribbonStationList";
            // 
            // ribbonConfiguration
            // 
            this.ribbonConfiguration.Caption = "Configuration";
            this.ribbonConfiguration.Id = 5;
            this.ribbonConfiguration.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonConfiguration.ImageOptions.Image")));
            this.ribbonConfiguration.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonConfiguration.ImageOptions.LargeImage")));
            this.ribbonConfiguration.Name = "ribbonConfiguration";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Station Manager";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonConfiguration);
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonCapturedImages);
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonStationList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Stations";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.ribbonActiveStations);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Status";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 613);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainView.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.ShowMdiChildCaptionInParentTitle = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KennaStation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabManager;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarMdiChildrenListItem ribbonActiveStations;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem ribbonCapturedImages;
        private DevExpress.XtraBars.BarListItem ribbonStationList;
        private DevExpress.XtraBars.BarButtonItem ribbonConfiguration;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}