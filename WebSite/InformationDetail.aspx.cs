﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformationDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string categoryType = Request.QueryString["id"];
            int categoryId = Convert.ToInt32(categoryType);
            if (null == categoryType || categoryType.Equals(string.Empty))
            {
                this.showFalseMessage("请输入正确的请求代号！");
                return;
            }

            ServiceNews serviceNews = new ServiceNews();
            string titleText = serviceNews.GetInformationName(categoryId);
            if (null == titleText || titleText.Equals(string.Empty))
            {
                this.showFalseMessage("新闻编号错误！");
                return;
            }

            this.TitleLabel.Text = titleText;
            string articleText = serviceNews.GetInformation(categoryId);
            if (null == articleText)
            {
                this.showFalseMessage("新闻读取错误！");
                return;
            }
            this.ContentLabel.Text = articleText;
        }
    }

    private void showFalseMessage(string message)
    {
        this.failure_div.Visible = true;
        this.success_div.Visible = false;

        this.failure_div.InnerText = message;
    }
}