/*******************************************************************************
* Copyright (C)  opcomunity.com
* 
* Author: dj.wong
* Create Date: 2015/8/7 11:12:12
* Description: Automated building by service@opcomunity.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System.Linq;
using AutoMapper;
using BackStage.Entity;
using BackStage.Service.Enum;
using BackStage.Service.Dto;

namespace BackStage.Service
{
    /// <summary>
    /// AutoMapper 自定义扩展配置
    /// </summary>
    public partial class AutoMapperConfiguration
    {
        /// <summary>
        /// AutoMapper 自定义扩展配置
        /// </summary>
        public static void ConfigExt()
        {
            Mapper.CreateMap<UserDto, UserEntity>()
                .ForMember(u => u.Status, e => e.MapFrom(s => (byte) s.Status));

            Mapper.CreateMap<UserEntity, UserDto>()
                .ForMember(u => u.Status, e => e.MapFrom(s => (UserStatus) s.Status));

            Mapper.CreateMap<MenuDto, MenuEntity>()
                .ForMember(u => u.Type, e => e.MapFrom(s => (byte)s.Type));

            Mapper.CreateMap<MenuEntity, MenuDto>()
                .ForMember(u => u.Type, e => e.MapFrom(s => (MenuType)s.Type));

            Mapper.CreateMap<EmailPoolDto, EmailPoolEntity>()
                .ForMember(u => u.Status, e => e.MapFrom(s => (byte) s.Status));

            Mapper.CreateMap<EmailPoolEntity, EmailPoolDto>()
                .ForMember(u => u.Status, e => e.MapFrom(s => (EmailStatus) s.Status))
                .ForMember(u => u.Receivers, e => e.MapFrom(s => s.Receivers.ToList()));

            Mapper.CreateMap<EmailReceiverDto, EmailReceiverEntity>()
                .ForMember(u => u.Type, e => e.MapFrom(s => (byte)s.Type));

            Mapper.CreateMap<EmailReceiverEntity, EmailReceiverDto>()
                .ForMember(u => u.Type, e => e.MapFrom(s => (EmailReceiverType)s.Type));
        }
    }
}
