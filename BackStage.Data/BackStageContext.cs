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
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BackStage.Data.Config;

namespace BackStage.Data
{
    /// <summary>
    /// BackStageContext
    /// </summary>
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BackStageContext : DbContext
    {
        /// <summary>
        /// BackStageContext
        /// </summary>
        public BackStageContext() : base("BackStageContext")
        {
            //SQL语句拦截器
            //System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new SqlCommandInterceptor());
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串名称</param>
        public BackStageContext(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除关系
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //移除表名复数形式
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //配置实体和数据表的关系
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new MenuConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new RoleMenuConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());
            modelBuilder.Configurations.Add(new LoginLogConfig());
            modelBuilder.Configurations.Add(new PageViewConfig());
            modelBuilder.Configurations.Add(new EmailPoolConfig());
            modelBuilder.Configurations.Add(new EmailReceiverConfig());
        }
    }
}
