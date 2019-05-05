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
using System.Web.Optimization;

namespace BackStage.Web
{
    public class BackStageScriptBundle : ScriptBundle
    {
        readonly JavascriptObfuscator _jso = new JavascriptObfuscator();

        public BackStageScriptBundle(string virtrualPath)
            : base(virtrualPath)
        {
            Transforms.Add(_jso);
        }
    }
}