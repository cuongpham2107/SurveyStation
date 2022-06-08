namespace PcControl {
    partial class CameraView {
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
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.controlPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlay = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapture = new DevExpress.XtraEditors.SimpleButton();
            this.btnStream = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.teLens = new DevExpress.XtraEditors.TextEdit();
            this.teZoom = new DevExpress.XtraEditors.TextEdit();
            this.tbLens = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.tbZoom = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.btnLensOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnLensIn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnMove = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveLeft = new DevExpress.XtraEditors.SimpleButton();
            this.teUpDown = new DevExpress.XtraEditors.TextEdit();
            this.teLeftRight = new DevExpress.XtraEditors.TextEdit();
            this.tbUpDown = new DevExpress.XtraEditors.TrackBarControl();
            this.tbLeftRight = new DevExpress.XtraEditors.TrackBarControl();
            this.btnMoveRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.logPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lbLog = new DevExpress.XtraEditors.ListBoxControl();
            this.imagePanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lbImage = new DevExpress.XtraEditors.ListBoxControl();
            this.cameraPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.cbbResolutions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teLens.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLens.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUpDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLeftRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight.Properties)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbLog)).BeginInit();
            this.imagePanel.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).BeginInit();
            this.cameraPanel.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.controlPanel,
            this.panelContainer1,
            this.cameraPanel});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.dockPanel1_Container);
            this.controlPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.controlPanel.ID = new System.Guid("3fe4f53f-768e-4e4c-a392-24fb37e55a4e");
            this.controlPanel.Location = new System.Drawing.Point(832, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Options.ResizeDirection = ((DevExpress.XtraBars.Docking.Helpers.ResizeDirection)((DevExpress.XtraBars.Docking.Helpers.ResizeDirection.Top | DevExpress.XtraBars.Docking.Helpers.ResizeDirection.Bottom)));
            this.controlPanel.Options.ShowCloseButton = false;
            this.controlPanel.OriginalSize = new System.Drawing.Size(250, 200);
            this.controlPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.controlPanel.SavedIndex = 0;
            this.controlPanel.Size = new System.Drawing.Size(250, 656);
            this.controlPanel.Text = "Control";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.groupControl3);
            this.dockPanel1_Container.Controls.Add(this.groupControl2);
            this.dockPanel1_Container.Controls.Add(this.groupControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(244, 627);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl3.CaptionImageOptions.SvgImage")));
            this.groupControl3.Controls.Add(this.cbbResolutions);
            this.groupControl3.Controls.Add(this.btnPause);
            this.groupControl3.Controls.Add(this.btnPlay);
            this.groupControl3.Controls.Add(this.btnCapture);
            this.groupControl3.Controls.Add(this.btnStream);
            this.groupControl3.Controls.Add(this.btnStop);
            this.groupControl3.Location = new System.Drawing.Point(8, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(228, 186);
            this.groupControl3.TabIndex = 10;
            this.groupControl3.Text = "Camera";
            // 
            // btnPause
            // 
            this.btnPause.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.ImageOptions.Image")));
            this.btnPause.Location = new System.Drawing.Point(121, 80);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 32);
            this.btnPause.TabIndex = 10;
            this.btnPause.Text = "Pause";
            // 
            // btnPlay
            // 
            this.btnPlay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.ImageOptions.Image")));
            this.btnPlay.Location = new System.Drawing.Point(35, 80);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 32);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            // 
            // btnCapture
            // 
            this.btnCapture.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.ImageOptions.Image")));
            this.btnCapture.Location = new System.Drawing.Point(35, 118);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(166, 32);
            this.btnCapture.TabIndex = 8;
            this.btnCapture.Text = "Capture";
            // 
            // btnStream
            // 
            this.btnStream.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStream.ImageOptions.Image")));
            this.btnStream.Location = new System.Drawing.Point(35, 42);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(80, 32);
            this.btnStream.TabIndex = 6;
            this.btnStream.Text = "Stream";
            // 
            // btnStop
            // 
            this.btnStop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.ImageOptions.Image")));
            this.btnStop.Location = new System.Drawing.Point(121, 42);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 32);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.teLens);
            this.groupControl2.Controls.Add(this.teZoom);
            this.groupControl2.Controls.Add(this.tbLens);
            this.groupControl2.Controls.Add(this.tbZoom);
            this.groupControl2.Controls.Add(this.btnLensOut);
            this.groupControl2.Controls.Add(this.btnZoomIn);
            this.groupControl2.Controls.Add(this.btnZoomOut);
            this.groupControl2.Controls.Add(this.btnLensIn);
            this.groupControl2.Location = new System.Drawing.Point(8, 446);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(228, 178);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "Lens";
            // 
            // teLens
            // 
            this.teLens.Location = new System.Drawing.Point(179, 112);
            this.teLens.Name = "teLens";
            this.teLens.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.teLens.Properties.MaskSettings.Set("mask", "d");
            this.teLens.Size = new System.Drawing.Size(39, 20);
            this.teLens.TabIndex = 11;
            // 
            // teZoom
            // 
            this.teZoom.Location = new System.Drawing.Point(179, 36);
            this.teZoom.Name = "teZoom";
            this.teZoom.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.teZoom.Properties.MaskSettings.Set("mask", "d");
            this.teZoom.Size = new System.Drawing.Size(39, 20);
            this.teZoom.TabIndex = 10;
            // 
            // tbLens
            // 
            this.tbLens.EditValue = null;
            this.tbLens.Location = new System.Drawing.Point(5, 114);
            this.tbLens.Name = "tbLens";
            this.tbLens.Properties.LargeChange = 1;
            this.tbLens.Size = new System.Drawing.Size(170, 18);
            this.tbLens.TabIndex = 9;
            // 
            // tbZoom
            // 
            this.tbZoom.EditValue = null;
            this.tbZoom.Location = new System.Drawing.Point(5, 36);
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Properties.LargeChange = 1;
            this.tbZoom.Properties.Middle = 5;
            this.tbZoom.Size = new System.Drawing.Size(170, 18);
            this.tbZoom.TabIndex = 8;
            // 
            // btnLensOut
            // 
            this.btnLensOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLensOut.ImageOptions.Image")));
            this.btnLensOut.Location = new System.Drawing.Point(9, 138);
            this.btnLensOut.Name = "btnLensOut";
            this.btnLensOut.Size = new System.Drawing.Size(100, 32);
            this.btnLensOut.TabIndex = 7;
            this.btnLensOut.Text = "Lens out";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.ImageOptions.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(118, 60);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(100, 32);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "Zoom in";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.ImageOptions.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(9, 60);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(100, 32);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "Zoom out";
            // 
            // btnLensIn
            // 
            this.btnLensIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLensIn.ImageOptions.Image")));
            this.btnLensIn.Location = new System.Drawing.Point(118, 138);
            this.btnLensIn.Name = "btnLensIn";
            this.btnLensIn.Size = new System.Drawing.Size(100, 32);
            this.btnLensIn.TabIndex = 6;
            this.btnLensIn.Text = "Lens in";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.btnMove);
            this.groupControl1.Controls.Add(this.btnMoveLeft);
            this.groupControl1.Controls.Add(this.teUpDown);
            this.groupControl1.Controls.Add(this.teLeftRight);
            this.groupControl1.Controls.Add(this.tbUpDown);
            this.groupControl1.Controls.Add(this.tbLeftRight);
            this.groupControl1.Controls.Add(this.btnMoveRight);
            this.groupControl1.Controls.Add(this.btnMoveUp);
            this.groupControl1.Controls.Add(this.btnMoveDown);
            this.groupControl1.Location = new System.Drawing.Point(8, 195);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(228, 245);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Motor";
            // 
            // btnMove
            // 
            this.btnMove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.ImageOptions.Image")));
            this.btnMove.Location = new System.Drawing.Point(104, 100);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(55, 55);
            this.btnMove.TabIndex = 8;
            this.btnMove.Text = "Move";
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLeft.ImageOptions.Image")));
            this.btnMoveLeft.Location = new System.Drawing.Point(44, 100);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(55, 55);
            this.btnMoveLeft.TabIndex = 0;
            this.btnMoveLeft.Text = "Left";
            // 
            // teUpDown
            // 
            this.teUpDown.Location = new System.Drawing.Point(46, 40);
            this.teUpDown.Name = "teUpDown";
            this.teUpDown.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.teUpDown.Properties.MaskSettings.Set("mask", "d");
            this.teUpDown.Size = new System.Drawing.Size(35, 20);
            this.teUpDown.TabIndex = 7;
            // 
            // teLeftRight
            // 
            this.teLeftRight.EditValue = "";
            this.teLeftRight.Location = new System.Drawing.Point(183, 191);
            this.teLeftRight.Name = "teLeftRight";
            this.teLeftRight.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.teLeftRight.Properties.MaskSettings.Set("mask", "d");
            this.teLeftRight.Size = new System.Drawing.Size(35, 20);
            this.teLeftRight.TabIndex = 6;
            // 
            // tbUpDown
            // 
            this.tbUpDown.EditValue = 45;
            this.tbUpDown.Location = new System.Drawing.Point(-4, 37);
            this.tbUpDown.Name = "tbUpDown";
            this.tbUpDown.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbUpDown.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbUpDown.Properties.LargeChange = 10;
            this.tbUpDown.Properties.Maximum = 360;
            this.tbUpDown.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbUpDown.Properties.ShowLabels = true;
            this.tbUpDown.Properties.SmallChange = 5;
            this.tbUpDown.Properties.TickFrequency = 10;
            this.tbUpDown.Properties.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbUpDown.Size = new System.Drawing.Size(45, 186);
            this.tbUpDown.TabIndex = 5;
            this.tbUpDown.Value = 45;
            // 
            // tbLeftRight
            // 
            this.tbLeftRight.EditValue = 45;
            this.tbLeftRight.Location = new System.Drawing.Point(30, 216);
            this.tbLeftRight.Name = "tbLeftRight";
            this.tbLeftRight.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbLeftRight.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbLeftRight.Properties.LargeChange = 10;
            this.tbLeftRight.Properties.Maximum = 180;
            this.tbLeftRight.Properties.ShowLabels = true;
            this.tbLeftRight.Properties.SmallChange = 5;
            this.tbLeftRight.Properties.TickFrequency = 10;
            this.tbLeftRight.Size = new System.Drawing.Size(193, 45);
            this.tbLeftRight.TabIndex = 4;
            this.tbLeftRight.Value = 45;
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRight.ImageOptions.Image")));
            this.btnMoveRight.Location = new System.Drawing.Point(163, 100);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(55, 55);
            this.btnMoveRight.TabIndex = 1;
            this.btnMoveRight.Text = "Right";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.ImageOptions.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(104, 43);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(55, 55);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Up";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.ImageOptions.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(104, 159);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(55, 55);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "Down";
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.logPanel;
            this.panelContainer1.Controls.Add(this.logPanel);
            this.panelContainer1.Controls.Add(this.imagePanel);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("e8132817-46bf-4eff-863e-fe1fb97cc461");
            this.panelContainer1.Location = new System.Drawing.Point(0, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(250, 200);
            this.panelContainer1.Size = new System.Drawing.Size(250, 656);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.dockPanel2_Container);
            customHeaderButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("customHeaderButtonImageOptions1.Image")));
            this.logPanel.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Clear", true, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject1, "clear", -1)});
            this.logPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.logPanel.FloatVertical = true;
            this.logPanel.ID = new System.Guid("e734730e-7a53-452f-af84-098e26f6c560");
            this.logPanel.Location = new System.Drawing.Point(3, 32);
            this.logPanel.Name = "logPanel";
            this.logPanel.Options.ShowCloseButton = false;
            this.logPanel.OriginalSize = new System.Drawing.Size(243, 570);
            this.logPanel.Size = new System.Drawing.Size(243, 595);
            this.logPanel.Text = "Log";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.lbLog);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(243, 595);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.Location = new System.Drawing.Point(0, 0);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(243, 595);
            this.lbLog.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.lbLog.TabIndex = 0;
            // 
            // imagePanel
            // 
            this.imagePanel.Controls.Add(this.controlContainer1);
            this.imagePanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.imagePanel.ID = new System.Guid("82e17a0c-9ca0-4356-9b69-08b972699465");
            this.imagePanel.Location = new System.Drawing.Point(3, 32);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Options.ShowCloseButton = false;
            this.imagePanel.OriginalSize = new System.Drawing.Size(243, 570);
            this.imagePanel.Size = new System.Drawing.Size(243, 595);
            this.imagePanel.Text = "Image";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.lbImage);
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(243, 595);
            this.controlContainer1.TabIndex = 0;
            // 
            // lbImage
            // 
            this.lbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImage.Location = new System.Drawing.Point(0, 0);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(243, 595);
            this.lbImage.TabIndex = 0;
            // 
            // cameraPanel
            // 
            this.cameraPanel.Controls.Add(this.dockPanel3_Container);
            this.cameraPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.cameraPanel.ID = new System.Guid("dfeb0c4d-9fc1-4f74-b0cb-067ad9b20ac2");
            this.cameraPanel.Location = new System.Drawing.Point(250, 0);
            this.cameraPanel.Name = "cameraPanel";
            this.cameraPanel.Options.ShowCloseButton = false;
            this.cameraPanel.OriginalSize = new System.Drawing.Size(511, 200);
            this.cameraPanel.Size = new System.Drawing.Size(582, 656);
            this.cameraPanel.Text = "Camera";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.videoView);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(576, 627);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.Black;
            this.videoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(576, 627);
            this.videoView.TabIndex = 0;
            this.videoView.Text = "videoView1";
            // 
            // cbbResolutions
            // 
            this.cbbResolutions.FormattingEnabled = true;
            this.cbbResolutions.Location = new System.Drawing.Point(35, 156);
            this.cbbResolutions.Name = "cbbResolutions";
            this.cbbResolutions.Size = new System.Drawing.Size(166, 21);
            this.cbbResolutions.TabIndex = 11;
            // 
            // CameraView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 656);
            this.Controls.Add(this.cameraPanel);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.controlPanel);
            this.Name = "CameraView";
            this.Text = "CameraView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teLens.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLens.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUpDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLeftRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftRight)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbLog)).EndInit();
            this.imagePanel.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbImage)).EndInit();
            this.cameraPanel.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel cameraPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel logPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel controlPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private LibVLCSharp.WinForms.VideoView videoView;
        private DevExpress.XtraEditors.SimpleButton btnLensOut;
        private DevExpress.XtraEditors.SimpleButton btnLensIn;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp;
        private DevExpress.XtraEditors.SimpleButton btnMoveRight;
        private DevExpress.XtraEditors.SimpleButton btnMoveLeft;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnCapture;
        private DevExpress.XtraEditors.SimpleButton btnStream;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.ListBoxControl lbLog;
        private DevExpress.XtraEditors.TrackBarControl tbLeftRight;
        private DevExpress.XtraEditors.TrackBarControl tbUpDown;
        private DevExpress.XtraEditors.ZoomTrackBarControl tbLens;
        private DevExpress.XtraEditors.ZoomTrackBarControl tbZoom;
        private DevExpress.XtraEditors.SimpleButton btnPlay;
        private DevExpress.XtraEditors.TextEdit teUpDown;
        private DevExpress.XtraEditors.TextEdit teLeftRight;
        private DevExpress.XtraEditors.TextEdit teLens;
        private DevExpress.XtraEditors.TextEdit teZoom;
        private DevExpress.XtraBars.Docking.DockPanel imagePanel;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.ListBoxControl lbImage;
        private DevExpress.XtraEditors.SimpleButton btnMove;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraEditors.SimpleButton btnPause;
        private ComboBox cbbResolutions;
    }
}