﻿/*******************************************************************************
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
    /// 角色表配置
    /// </summary>
    public class UserRoleConfig : EntityTypeConfiguration<UserRoleEntity>
    {
        public UserRoleConfig()
        {
            ToTable("UserRole");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.RoleId).IsRequired();
            Property(item => item.UserId).IsRequired();
            HasRequired(item => item.User).WithMany(item => item.UserRoles).HasForeignKey(item => item.UserId);
        }
    }
}
