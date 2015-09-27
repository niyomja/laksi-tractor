using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;
using appTractor.View;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using appTractor.Model;
using appTractor.helper;

namespace appTractor.Controller
{
    class InventoryController : IControllerBase
    {
        #region [Private Properties]
        private User user;
        private ucInventory view;
        private PartModel partModel;
        private CustomerModel customerModel;
        private PartInventoryModel partInventoryModel;
        private int brandId;
        private int partId;
        #endregion

        #region [Default Constructor]
        public InventoryController() {
            partModel = new PartModel();
            partInventoryModel = new PartInventoryModel();
            customerModel = new CustomerModel();

            view = new ucInventory();
            view.Dock = DockStyle.Fill;

            buildGridViewInventory();

            #region Inventory Events
            view.dgvInventory.CellValueChanged += new DataGridViewCellEventHandler(dgvInventory_CellValueChanged);

            view.toolBtnDeleteInventory.Click += new EventHandler(toolBtnDeleteInventory_Click);

            view.bsInventory.CurrentItemChanged += new EventHandler(bsInventory_CurrentItemChanged);

            view.dgvInventory.DataError += new DataGridViewDataErrorEventHandler(dgvInventory_DataError);

            view.dgvInventory.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvInventory_EditingControlShowing);

            view.dgvInventory.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvInventory_CellFormatting);

            view.toolBtnAddInventory.Click += new EventHandler(toolBtnAddInventory_Click);
            #endregion

            #region Part Events
            view.btnSearchPart.Click += new EventHandler(btnSearchPart_Click);

            view.dgPartNo.CellValueChanged += new DataGridViewCellEventHandler(dgPartNo_CellValueChanged);

            view.dgPartNo.DataError += new DataGridViewDataErrorEventHandler(dgPartNo_DataError);

            view.dgPartNo.CellFormatting += new DataGridViewCellFormattingEventHandler(dgPartNo_CellFormatting);

            view.toolBtnDeletePart.Click += new EventHandler(toolBtnDeletePart_Click);
            
            view.bindingNavPartNoAddNewItem.Click += new EventHandler(bindingNavigatorAddNewItem_Click);

            view.bsPartList.PositionChanged += new EventHandler(bsPartList_PositionChanged);

           
            #endregion
        }

        #endregion

        #region [Part Events Handler]

        void bsPartList_PositionChanged(object sender, EventArgs e)
        {
            if (view.bsPartList.Current != null)
            {
                var cPart = (Part)view.bsPartList.Current;
                List<PartInventory> partInventories = partInventoryModel.getPartInventoryByPartId(cPart.PartID);
                view.bsInventory.DataSource = partInventories;

                partId = cPart.PartID;

                //enable add inventory
                view.toolBtnAddInventory.Visible = (cPart.PartID > 0);
            }
            else
            {
                partId = 0;
                view.bsInventory.DataSource = null;
                view.toolBtnAddInventory.Visible = false;
            }

            enable_delete_part(view.bsPartList.Current != null);
        }

        private void dgPartNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                if (Convert.ToDecimal(e.Value) == 0)
                {
                    e.Value = "";
                }
            }
        }

        private void dgPartNo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (view.bsPartList.Current != null)
            {
                var cPart = (Part)view.bsPartList.Current;
                cPart.is_new = true;
                enable_add_part(false);
            }
        }

        private void toolBtnDeletePart_Click(object sender, EventArgs e)
        {
            enable_add_part(true);

            if (view.bsPartList.Current != null)
            {

                try
                {
                    var cPart = (Part)view.bsPartList.Current;
                    if (!String.IsNullOrEmpty(cPart.PartNo) && MessageBox.Show("ต้องการลบข้อมูลของ Part No. " + cPart.PartNo + " ใช่ หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    if (cPart.PartID > 0)
                    {
                        partModel.delete(cPart.PartID, user.UserID);
                    }
                    view.dgPartNo.BindingContext[cPart].EndCurrentEdit();
                    view.bsPartList.RemoveCurrent();

                    view.toolBtnAddInventory.Visible = (view.bsPartList.Count > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                view.toolBtnAddInventory.Visible = false;
            }
        }

        private void dgPartNo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            saveUpdatePart();
        }

        private void saveUpdatePart()
        {
            if (view.bsPartList.Current != null)
            {
                try
                {
                    var cPart = (Part)view.bsPartList.Current;
                    
                    if (String.IsNullOrEmpty(cPart.PartNo)) {
                        return;
                    }

                    if (cPart.is_new)
                    {
                        cPart.BrandID = brandId;
                        cPart.PartNo = (!String.IsNullOrEmpty(cPart.PartNo)) ? cPart.PartNo : "";
                        cPart.LocIM = view.txtLocIM.Text;
                        cPart.LocG = view.txtLocG.Text;
                        cPart.Comment = view.txtComment.Text;
                        int id = partModel.createPart(cPart, user.UserID);
                        if (id > 0)
                        {
                            cPart.PartID = id;
                            cPart.is_new = false;
                            enable_add_part(true);
                            enable_add_inventory(true);
                        }
                    }
                    else
                    {
                        cPart.LocIM = view.txtLocIM.Text;
                        cPart.LocG = view.txtLocG.Text;
                        cPart.Comment = view.txtComment.Text;
                        if (partModel.UpdatePart(cPart, user.UserID))
                        {
                            enable_add_part(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void enable_delete_part(bool enabled)
        {
            view.toolBtnDeletePart.Visible = enabled;
        }

        private void bindingPartList()
        {
            view.bsPartList.DataSource = partModel.getPartsByBrandId(brandId);

            enable_add_part(true);
        }

        private void enable_add_part(bool enabled)
        {
            view.bindingNavPartNoAddNewItem.Visible = enabled;
        }

        private void btnSearchPart_Click(object sender, EventArgs e)
        {
            PartModel partModel = new PartModel();
            var parts = partModel.getPartsByBrandIdPartNo(brandId, view.txtKeyword.Text);

            view.bsPartList.DataSource = parts;

            enable_add_part(true);

        }
        #endregion

        #region [Events Inventory Handler]

        private void buildGridViewInventory()
        {
            view.dgvInventory.Columns.Clear();
            view.dgvInventory.ReadOnly = false;
            view.dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewRow row = view.dgvInventory.RowTemplate;
            row.Height = 35;
            row.MinimumHeight = 26;

            DataGridViewCellStyle cellStyleMiddleRight = new DataGridViewCellStyle();
            cellStyleMiddleRight.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewCellStyle cellStyleColor1 = new DataGridViewCellStyle();
            cellStyleColor1.BackColor = Color.WhiteSmoke;
            cellStyleColor1.Alignment = DataGridViewContentAlignment.MiddleRight;

            CalendarColumn colDate = new CalendarColumn();
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDate.Width = 100;
            colDate.DataPropertyName = "regDate";
            view.dgvInventory.Columns.Add(colDate);

            DataGridViewTextBoxColumn colDOINVNO = new DataGridViewTextBoxColumn();
            colDOINVNO.HeaderText = "D.O Invoice No.";
            colDOINVNO.Name = "colDOINVNO";
            colDOINVNO.DataPropertyName = "DOInvoiceNo";
            colDOINVNO.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDOINVNO.Width = 130;
            view.dgvInventory.Columns.Add(colDOINVNO);

            DataGridViewComboBoxColumn colCustomer = new DataGridViewComboBoxColumn();
            colCustomer.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colCustomer.HeaderText = "Customer";
            colCustomer.Name = "colCustomer";
            colCustomer.DataSource = customerModel.getAllCustomers();
            colCustomer.DisplayMember = "customerName";
            colCustomer.ValueMember = "customerID";
            colCustomer.DataPropertyName = "customerId";

            view.dgvInventory.Columns.Add(colCustomer);

            DataGridViewTextBoxColumn colRecD = new DataGridViewTextBoxColumn();
            colRecD.HeaderText = "REC'D";
            colRecD.DefaultCellStyle = cellStyleMiddleRight;
            colRecD.Name = "colRecD";
            colRecD.DataPropertyName = "recd";
            colRecD.ValueType = typeof(int);
            colRecD.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colRecD.Width = 80;
            view.dgvInventory.Columns.Add(colRecD);

            DataGridViewTextBoxColumn colLSold = new DataGridViewTextBoxColumn();
            colLSold.HeaderText = "Sold";
            colLSold.DefaultCellStyle = cellStyleMiddleRight;
            colLSold.Name = "colLSold";
            colLSold.DataPropertyName = "lSold";
            colLSold.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colLSold.Width = 80;
            view.dgvInventory.Columns.Add(colLSold);

            DataGridViewTextBoxColumn colGOnHand = new DataGridViewTextBoxColumn();
            colGOnHand.ReadOnly = true;
            colGOnHand.DefaultCellStyle = cellStyleMiddleRight;
            colGOnHand.Name = "colGOnHand";
            colGOnHand.HeaderText = "G. On Hand";
            colGOnHand.DataPropertyName = "gOnHand";
            colGOnHand.DefaultCellStyle = cellStyleColor1;
            view.dgvInventory.Columns.Add(colGOnHand);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.HeaderText = "Price 1";
            colPrice.DefaultCellStyle = cellStyleMiddleRight;
            colPrice.Name = "colPrice";
            colPrice.DataPropertyName = "price";
            colPrice.ValueType = Type.GetType("System.Decimal");
            colPrice.DefaultCellStyle.Format = "0.00##";
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrice.Width = 80;
            view.dgvInventory.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colLRecD = new DataGridViewTextBoxColumn();
            colLRecD.HeaderText = "REC'D";
            colLRecD.DefaultCellStyle = cellStyleMiddleRight;
            colLRecD.Name = "colRecD";
            colLRecD.DataPropertyName = "oemRecd";
            colLRecD.ValueType = typeof(int);
            colLRecD.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colRecD.Width = 80;
            view.dgvInventory.Columns.Add(colLRecD);

            DataGridViewTextBoxColumn colRSold = new DataGridViewTextBoxColumn();
            colRSold.HeaderText = "Sold";
            colRSold.DefaultCellStyle = cellStyleMiddleRight;
            colRSold.Name = "colRSold";
            colRSold.DataPropertyName = "rSold";
            colRSold.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colRSold.Width = 80;
            view.dgvInventory.Columns.Add(colRSold);

            DataGridViewTextBoxColumn colIMOnHand = new DataGridViewTextBoxColumn();
            colIMOnHand.HeaderText = "OEM On Hand";
            colIMOnHand.ReadOnly = true;
            colIMOnHand.DefaultCellStyle = cellStyleMiddleRight;
            colIMOnHand.Name = "colIMOnHand";
            colIMOnHand.DataPropertyName = "imOnHand";
            colIMOnHand.DefaultCellStyle = cellStyleColor1;
            view.dgvInventory.Columns.Add(colIMOnHand);

            DataGridViewTextBoxColumn colPrice2 = new DataGridViewTextBoxColumn();
            colPrice2.HeaderText = "Price 2";
            colPrice2.DefaultCellStyle = cellStyleMiddleRight;
            colPrice2.Name = "colPrice";
            colPrice2.DataPropertyName = "price2";
            colPrice2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrice2.Width = 80;
            colPrice2.ValueType = Type.GetType("System.Decimal");
            colPrice2.DefaultCellStyle.Format = "0.00##";
            view.dgvInventory.Columns.Add(colPrice2);

            DataGridViewTextBoxColumn colTotalAvailabel = new DataGridViewTextBoxColumn();
            colTotalAvailabel.ReadOnly = true;
            colTotalAvailabel.DefaultCellStyle = cellStyleMiddleRight;
            colTotalAvailabel.Name = "colTotalAvailabel";
            colTotalAvailabel.HeaderText = "Total Availabel";
            colTotalAvailabel.DataPropertyName = "totalAvailabel";
            colTotalAvailabel.DefaultCellStyle = cellStyleColor1;
            view.dgvInventory.Columns.Add(colTotalAvailabel);

            DataGridViewTextBoxColumn colTotalDemand = new DataGridViewTextBoxColumn();
            colTotalDemand.ReadOnly = true;
            colTotalDemand.DefaultCellStyle = cellStyleMiddleRight;
            colTotalDemand.Name = "colTotalDemand";
            colTotalDemand.HeaderText = "Total Demand";
            colTotalDemand.DataPropertyName = "totalDemand";
            colTotalDemand.DefaultCellStyle = cellStyleColor1;
            view.dgvInventory.Columns.Add(colTotalDemand);

            DataGridViewTextBoxColumn colDetail = new DataGridViewTextBoxColumn();
            colDetail.HeaderText = "Remark";
            colDetail.Name = "colDetail";
            colDetail.DataPropertyName = "detail";
            view.dgvInventory.Columns.Add(colDetail);
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCellStyle cellStyleColor1 = new DataGridViewCellStyle();
            cellStyleColor1.ForeColor = Color.Red;
            DataGridViewCellStyle cellStyleColor2 = new DataGridViewCellStyle();
            cellStyleColor2.ForeColor = Color.Blue;

            if (e.ColumnIndex == 3 || e.ColumnIndex == 7)
            {
                if (e.Value != null && Convert.ToInt32(e.Value) > 0)
                {
                    view.dgvInventory.Rows[e.RowIndex].DefaultCellStyle = cellStyleColor1;
                }
            }
            

            if (e.ColumnIndex != 0 && e.ColumnIndex != 1 && e.ColumnIndex != 2 && e.ColumnIndex != 13)
            {
                if (e.Value != null && Convert.ToInt32(e.Value) == 0)
                {
                    e.Value = "";
                }
            }

        }

        private void toolBtnAddInventory_Click(object sender, EventArgs e)
        {
            if (view.bsInventory.Current != null)
            {
                var cPartInventory = (PartInventory)view.bsInventory.Current;
                cPartInventory.regDate = DateTime.Now;
            }
        }

        private void dgvInventory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void dgvInventory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).Size = new Size(300, 36);
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void toolBtnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (view.bsInventory.Current != null) {
                var partInventory = (PartInventory)view.bsInventory.Current;
                if (!String.IsNullOrEmpty(partInventory.DOInvoiceNo) && MessageBox.Show("ต้องการลบข้อมูลของ D.O Invoice No. " + partInventory.DOInvoiceNo + " ใช่ หรือไม่ ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                if (partInventory.partInventoryId > 0)
                {
                    partInventoryModel.delete(partInventory.partInventoryId, user.UserID);

                    //get and calculate data
                    List<PartInventory> partInventories = partInventoryModel.getPartInventoryByPartId(partInventory.partId);
                    view.bsInventory.DataSource = partInventories;

                    //update part inventory all 
                    foreach (PartInventory pinventoty in partInventories)
                    {
                        partInventoryModel.update(pinventoty, user.UserID);
                    }
                }
                else {
                    view.dgvInventory.BindingContext[partInventory].EndCurrentEdit();
                    view.bsInventory.RemoveCurrent();
                }

                enable_add_inventory(view.bsInventory.Count > 0);
            }
            
            enable_delete_inventory(view.bsInventory.Current != null);
        }

        private void enable_add_inventory(bool enabled)
        {
            view.toolBtnAddInventory.Visible = enabled;
        }

        private void enable_delete_inventory(bool enabled)
        {
            view.toolBtnDeleteInventory.Visible = enabled;
        }

        private void bsInventory_CurrentItemChanged(object sender, EventArgs e)
        {
            enable_delete_inventory(view.bsInventory.Current != null);
        }

        private void dgvInventory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (view.bsInventory.Current != null) {
                try
                {
                    var cPartInventory = (PartInventory)view.bsInventory.Current;
                    if (cPartInventory.partInventoryId > 0)
                    {
                        //update part inventory 
                        partInventoryModel.update(cPartInventory, user.UserID);

                        //get and calculate data
                        List<PartInventory> partInventories = partInventoryModel.getPartInventoryByPartId(cPartInventory.partId);
                        view.bsInventory.DataSource = partInventories;

                        //update part inventory all 
                        foreach (PartInventory pinventoty in partInventories)
                        {
                            partInventoryModel.update(pinventoty, user.UserID);
                        }
                    }
                    else
                    {
                        if (view.bsPartList.Current != null)
                        {
                            var cPart = (Part)view.bsPartList.Current;

                            //insert part inventory 
                            cPartInventory.partId = cPart.PartID;
                            cPartInventory.DOInvoiceNo = (!String.IsNullOrEmpty(cPartInventory.DOInvoiceNo)) ? cPartInventory.DOInvoiceNo : "";
                            
                            int id = partInventoryModel.createPartInventory(cPartInventory, user.UserID);

                            if (id > 0)
                            {

                                //get and calculate data
                                List<PartInventory> partInventories = partInventoryModel.getPartInventoryByPartId(cPart.PartID);
                                view.bsInventory.DataSource = partInventories;

                                //update part inventory all 
                                foreach (PartInventory pinventoty in partInventories)
                                {
                                    partInventoryModel.update(pinventoty, user.UserID);
                                }

                                view.toolBtnDeleteInventory.Visible = false;
                            }
                        }
                    }

                    view.toolBtnDeleteInventory.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IControllerBase Members

        public void run(IControllerBase ctl)
        {
            var main = (HomeController)ctl;

            user = main.User;
            brandId = main.BrandID;

            main.Body.Controls.Clear();
            main.Body.Controls.Add(view);

            bindingPartList();

            //Binding Control Data
            view.txtLocG.DataBindings.Add("Text", view.bsPartList, "LocG");
            view.txtLocIM.DataBindings.Add("Text", view.bsPartList, "LocIM");
            view.txtComment.DataBindings.Add("Text", view.bsPartList, "Comment");

            view.txtLocG.Leave += new EventHandler(txtLocG_Leave);
            view.txtLocIM.Leave += new EventHandler(txtLocIM_Leave);
            view.txtComment.Leave += new EventHandler(txtComment_Leave);
        }

        void txtComment_Leave(object sender, EventArgs e)
        {
            saveUpdatePart();
        }

        void txtLocIM_Leave(object sender, EventArgs e)
        {
            saveUpdatePart();
        }

        void txtLocG_Leave(object sender, EventArgs e)
        {
            saveUpdatePart();
        }

        #endregion

    }
}
