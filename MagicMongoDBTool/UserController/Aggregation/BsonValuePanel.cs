﻿using MongoDB.Bson;
using System.Drawing;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class BsonValuePanel : UserControl
    {
        /// <summary>
        /// GroupItem数量
        /// </summary>
        private byte _conditionCount = 0;
        /// <summary>
        /// GroupItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);
        /// <summary>
        /// 构造器
        /// </summary>
        public BsonValuePanel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsonValuePanel_Load(object sender, System.EventArgs e)
        {
            AddBsonValueItem();
        }
        /// <summary>
        /// 增加BsonValueItem
        /// </summary>
        public void AddBsonValueItem()
        {
            _conditionCount++;
            ctlBsonValue newBsonValueItem = new ctlBsonValue();
            newBsonValueItem.Location = _conditionPos;
            newBsonValueItem.Name = "BsonValueItem" + _conditionCount.ToString();
            Controls.Add(newBsonValueItem);
            _conditionPos.Y += newBsonValueItem.Height;
        }
        /// <summary>
        /// 获得数组
        /// </summary>
        /// <returns></returns>
        public BsonArray GetBsonArray()
        {
            BsonArray ValueList = new BsonArray();
            foreach (ctlBsonValue item in this.Controls)
            {
                if (item.getValue() != null)
                {
                    ValueList.Add(item.getValue());
                }
            }
            return ValueList;
        }
        /// <summary>
        /// 清除所有数组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddBsonValueItem();
        }
    }
}
