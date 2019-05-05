/*******************************************************************************
* Copyright (C) opcomunity.com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@opcomunity.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BackStage.Entity;

namespace BackStage.Data.Config
{
    /// <summary>
    /// 邮件接收人表配置
    /// </summary>
    public class EmailReceiverConfig : EntityTypeConfiguration<EmailReceiverEntity>
    {
        public EmailReceiverConfig()
        {
            ToTable("EmailReceiver");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(item => item.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(item => item.Type).IsRequired();
            HasRequired(item => item.EmailPool).WithMany(item => item.Receivers).HasForeignKey(item => item.EmailId);
        }
    }
}
