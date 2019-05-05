/*******************************************************************************
* Copyright (C) opcomunity.com
* 
* Author: dj.wong
* Create Date: 2015/8/21
* Description: Automated building by service@opcomunity.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using System;
using System.Web.Optimization;

namespace BackStage.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //重新处理bundle忽略资源的规则
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            #region JS
            
            //控制面板通用js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/BaseScripts").Include(
                "~/Template/Admin/content/js/jquery-1.10.2.min.js",
                "~/Template/Admin/content/js/jquery-migrate.js",
                "~/Template/Admin/content/js/bootstrap.min.js",
                "~/Template/Admin/content/js/modernizr.min.js",
                "~/Template/Admin/content/js/jquery.nicescroll.js",
                "~/Template/Admin/content/js/slidebars.min.js",
                "~/Template/Admin/content/js/switchery/switchery.min.js",
                "~/Template/Admin/content/js/switchery/switchery-init.js",
                "~/Template/Admin/content/js/sparkline/jquery.sparkline.js",
                "~/Template/Admin/content/js/sparkline/sparkline-init.js",
                "~/Template/Admin/content/js/jquery.validate.min.js",
                "~/Template/Admin/content/js/json2.js",
                "~/Template/Admin/content/js/scripts.js"));

            bundles.Add(new BackStageScriptBundle("~/Template/Admin/content/JS/Layer/BaseLayer").Include(
                "~/Template/Admin/content/js/layer/layer.js"));

            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/JuCheap").Include(
                "~/Template/Admin/content/js/jucheap.js"));

            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/JuCheapMenu").Include(
                "~/Template/Admin/content/js/jucheap.menu.js"));

            

            //DataTable
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/DataTable").Include(
                "~/Template/Admin/content/js/data-table/js/jquery.dataTables.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.tableTools.min.js",
                "~/Template/Admin/content/js/data-table/js/bootstrap-dataTable.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.colVis.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.responsive.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.scroller.min.js",
                "~/Template/Admin/content/js/jucheap.tables.js"));

            //DataTable Demo Page
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/DataTableDemo").Include(
                "~/Template/Admin/content/js/data-table/js/jquery.dataTables.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.tableTools.min.js",
                "~/Template/Admin/content/js/data-table/js/bootstrap-dataTable.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.colVis.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.responsive.min.js",
                "~/Template/Admin/content/js/data-table/js/dataTables.scroller.min.js",
                "~/Template/Admin/content/js/data-table-init.js"));

            //tree
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Tree").Include(
                "~/Template/Admin/content/js/fuelux/js/tree.min.js"));

            //login page
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Login").Include(
                "~/Template/Admin/content/js/jquery-1.10.2.min.js",
                "~/Template/Admin/content/js/bootstrap.min.js", 
                "~/Template/Admin/content/js/jquery.validate.min.js",
                "~/Template/Admin/content/js/jucheap.login.valid.js"));

            //select2 js
            bundles.Add(new ScriptBundle("~/JS/Admin/content/Select").Include(
                "~/Template/Admin/content/js/select2.js",
                "~/Template/Admin/content/js/select2-init.js"));

            //nesttable js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Nestable").Include(
                "~/Template/Admin/content/js/nestable/jquery.nestable.js"));

            //tagsinput js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Tags").Include(
                "~/Template/Admin/content/js/tags-input.js",
                "~/Template/Admin/content/js/tags-input-init.js"));

            //fileinput js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/File").Include(
                "~/Template/Admin/content/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Template/Admin/content/js/file-input-init.js"));

            //email js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Email").Include(
                "~/Template/Admin/content/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Template/Admin/content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Template/Admin/content/js/bootstrap-fileinput-master/js/fileinput.js",
                "~/Template/Admin/content/js/file-input-init.js"));

            //editor js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/Editor").Include(
                "~/Template/Admin/content/js/bootstrap-wysihtml5/wysihtml5-0.3.0.js",
                "~/Template/Admin/content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Template/Admin/content/js/summernote/dist/summernote.min.js"));

            //icheck js
            bundles.Add(new BackStageScriptBundle("~/JS/Admin/content/FormValidate").Include(
                "~/Template/Admin/content/js/jquery.validate.min.js",
                "~/Template/Admin/content/js/form-validation-init.js",
                "~/Template/Admin/content/js/icheck/skins/icheck.min.js"));

            //Advance demo js
            bundles.Add(new ScriptBundle("~/JS/Admin/content/Advance").Include(
                "~/Template/Admin/content/js/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Template/Admin/content/js/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Template/Admin/content/js/bootstrap-daterangepicker/moment.min.js",
                "~/Template/Admin/content/js/bootstrap-daterangepicker/daterangepicker.js",
                "~/Template/Admin/content/js/bootstrap-colorpicker/js/bootstrap-colorpicker.js",
                "~/Template/Admin/content/js/bootstrap-timepicker/js/bootstrap-timepicker.js",
                "~/Template/Admin/content/js/picker-init.js",
                "~/Template/Admin/content/js/icheck/skins/icheck.min.js",
                "~/Template/Admin/content/js/icheck-init.js",
                "~/Template/Admin/content/js/tags-input.js",
                "~/Template/Admin/content/js/tags-input-init.js",
                "~/Template/Admin/content/js/touchspin.js",
                "~/Template/Admin/content/js/spinner-init.js",
                "~/Template/Admin/content/js/dropzone.js",
                "~/Template/Admin/content/js/select2.js",
                "~/Template/Admin/content/js/select2-init.js"));

            //flot chart demo
            bundles.Add(new ScriptBundle("~/JS/Admin/content/Chart").Include(
                "~/Template/admin/content/js/sparkline/jquery.sparkline.js",
                "~/Template/Admin/content/js/sparkline/sparkline-init.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.resize.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.tooltip.min.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.pie.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.selection.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.selection.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.stack.js",
                "~/Template/Admin/content/js/flot-chart/jquery.flot.crosshair.js",
                "~/Template/Admin/content/js/flot-chart-init.js"));

            //morris chart demo
            bundles.Add(new ScriptBundle("~/JS/Admin/content/ChartMorris").Include(
                "~/Template/admin/content/js/morris-chart/morris.js",
                "~/Template/Admin/content/js/morris-chart/raphael-min.js",
                "~/Template/Admin/content/js/morris-init.js"));

            //chartjs demo
            bundles.Add(new ScriptBundle("~/JS/Admin/content/ChartJs").Include(
                "~/Template/admin/content/js/chart-js/chart.js",
                "~/Template/Admin/content/js/chartJs-init.js"));

            bundles.Add(new BackStageScriptBundle("~/JS/Front/Web/Home").Include(
                "~/Template/front/web/js/jquery.js",
                "~/Template/front/web/js/bootstrap.min.js",
                "~/Template/front/web/js/jquery.prettyPhoto.js",
                "~/Template/front/web/js/jquery.isotope.min.js",
                "~/Template/front/web/js/main.js",
                "~/Template/front/web/js/wow.min.js"));

            bundles.Add(new ScriptBundle("~/JS/Kendo/content/Js").Include(
                "~/Template/Kendo/js/kendo.all.min.js",
                "~/Template/Custom/script.js"));

            bundles.Add(new ScriptBundle("~/JS/Kendo/custom/Js").Include(
                "~/Template/Custom/script.js"));
            #endregion

            #region CSS

            //Base Styles
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/BaseStyles").Include(
                "~/Template/Admin/content/css/style.css",
                "~/Template/Admin/content/css/style-responsive.css"));

            //Data Table
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/DataTable").Include(
                "~/Template/Admin/content/js/data-table/css/jquery.dataTables.css",
                "~/Template/Admin/content/js/data-table/css/dataTables.tableTools.css",
                "~/Template/Admin/content/js/data-table/css/dataTables.colVis.min.css",
                "~/Template/Admin/content/js/data-table/css/dataTables.responsive.css",
                "~/Template/Admin/content/js/data-table/css/dataTables.scroller.css"));

            //tree
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/TreeStyle").Include(
                "~/Template/Admin/content/js/fuelux/css/tree-style.css"));

            //select2
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/SelectStyle").Include(
                "~/Template/Admin/content/css/select2.css",
                "~/Template/Admin/content/css/select2-bootstrap.css"));

            //Nestable
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/Nestable").Include(
                "~/Template/Admin/content/js/nestable/jquery.nestable.css"));
            //Tagsinput
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/Tags").Include(
                "~/Template/Admin/content/css/tagsinput.css"));

            //FileInput
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/File").Include(
                "~/Template/Admin/content/js/bootstrap-fileinput-master/css/fileinput.css"));

            //Email
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/Email").Include(
                "~/Template/Admin/content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css",
                "~/Template/Admin/content/js/bootstrap-fileinput-master/css/fileinput.css"));

            //Editor
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/Editor").Include(
                "~/Template/Admin/content/js/summernote/dist/summernote.css",
                "~/Template/Admin/content/js/bootstrap-wysihtml5/bootstrap-wysihtml5.css"));

            //icheck Demo
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/FormValidate").Include(
                "~/Template/admin/content/js/icheck/skins/all.css"));

            //morris chart Demo
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/ChartMorris").Include(
                "~/Template/admin/content/js/morris-chart/morris.css"));

            //Advance Demo
            bundles.Add(new StyleBundle("~/Template/Admin/content/Css/Advance").Include(
                "~/Template/admin/content/js/icheck/skins/all.css",
                "~/Template/admin/content/css/tagsinput.css",
                //"~/Template/admin/content/css/dropzone.css",
                "~/Template/admin/content/css/select2.css",
                "~/Template/admin/content/css/select2-bootstrap.css",
                "~/Template/admin/content/css/bootstrap-touchspin.css",
                "~/Template/admin/content/js/bootstrap-datepicker/css/datepicker.css",
                "~/Template/admin/content/js/bootstrap-timepicker/compiled/timepicker.css",
                "~/Template/admin/content/js/bootstrap-colorpicker/css/colorpicker.css",
                "~/Template/admin/content/js/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Template/admin/content/js/bootstrap-datetimepicker/css/datetimepicker.css"));



            //front web/index
            bundles.Add(new StyleBundle("~/css/front/web/home").Include(
                "~/Template/front/web/css/bootstrap.min.css",
                "~/Template/front/web/css/font-awesome.min.css",
                "~/Template/front/web/css/animate.min.css",
                "~/Template/front/web/css/prettyPhoto.css",
                "~/Template/front/web/css/main.css",
                "~/Template/front/web/css/responsive.css"));

            //Editor
            bundles.Add(new StyleBundle("~/Template/Kendo/styles/Default").Include(
                "~/Template/Kendo/styles/kendo.common.min.css",
                "~/Template/Kendo/styles/kendo.dataviz.default.min.css",
                "~/Template/Kendo/styles/kendo.dataviz.min.css",
                "~/Template/Kendo/styles/kendo.default.min.css",
                "~/Template/Kendo/styles/kendo.default.mobile.min.css"));
            #endregion

            //BundleTable.EnableOptimizations = true;//强制启用压缩
        }
        /// <summary>
        /// 添加bundle需要忽略的表达式的资源
        /// </summary>
        /// <param name="ignoreList"></param>
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException(nameof(ignoreList));

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}