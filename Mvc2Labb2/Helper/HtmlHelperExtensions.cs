using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc2Labb2.Data;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Helper
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent OrderByLink(this IHtmlHelper htmlHelper,IUrlHelper urlHelper, LinkPartialViewModel model)
        {
            var actionLink = new TagBuilder("a");
            actionLink.MergeAttribute("href", urlHelper.Action(model.Action, model.Controller, new
            {
                propertyName = model.OrderByViewModel.PropertyName,
                orderBy = model.OrderByViewModel.OrderBy == OrderByType.Desc ? OrderByType.Asc : OrderByType.Desc,
                currentPage = model.PagingViewModel.CurrentPage,
                pageSize = model.PagingViewModel.PageSize
            }));

            switch (model.OrderByViewModel.OrderBy)
            {
                case OrderByType.Asc when model.DisplayName.Equals(model.OrderByViewModel.CurrentPropertyName, StringComparison.CurrentCultureIgnoreCase):
                {
                    var icon = new TagBuilder("i");
                    icon.AddCssClass("fas");
                    icon.AddCssClass("fa-sort-up");
                    actionLink.InnerHtml.Append(model.DisplayName);
                    actionLink.InnerHtml.AppendHtml(icon);
                        break;
                }
                case OrderByType.Desc when model.DisplayName.Equals(model.OrderByViewModel.CurrentPropertyName, StringComparison.CurrentCultureIgnoreCase):
                {
                    var icon = new TagBuilder("i");
                    icon.AddCssClass("fas");
                    icon.AddCssClass("fa-sort-down");
                    actionLink.InnerHtml.Append(model.DisplayName);
                    actionLink.InnerHtml.AppendHtml(icon);
                    break;
                }
                default:
                    actionLink.InnerHtml.SetContent($"{model.DisplayName}");
                    break;
            }
            
            return actionLink;
        }

        public static IHtmlContent PaginationLink(this IHtmlHelper htmlHelper, IUrlHelper urlHelper, LinkPartialViewModel model)
        {
            var actionLink = new TagBuilder("a");
            actionLink.MergeAttribute("href", urlHelper.Action(model.Action, model.Controller, new
            {
                propertyName = model.OrderByViewModel.PropertyName,
                orderBy = model.OrderByViewModel.OrderBy,
                currentPage = model.PagingViewModel.NextPage,
                pageSize = model.PagingViewModel.PageSize
            }));
            actionLink.InnerHtml.SetContent(model.DisplayName);
            actionLink.AddCssClass("page-link");

            return actionLink;
        }

        public static IHtmlContent PageSizeLink(this IHtmlHelper htmlHelper, IUrlHelper urlHelper, LinkPartialViewModel model)
        {
            var actionLink = new TagBuilder("a");
            actionLink.MergeAttribute("href", urlHelper.Action(model.Action, model.Controller, new
            {
                propertyName = model.OrderByViewModel.PropertyName,
                orderBy = model.OrderByViewModel.OrderBy,
                currentPage = model.PagingViewModel.NextPage,
                pageSize = model.PagingViewModel.PageSize
            }));
            actionLink.InnerHtml.SetContent(model.DisplayName);
            actionLink.AddCssClass("dropdown-item");
            actionLink.AddCssClass("page-link");

            return actionLink;
        }
    }
}