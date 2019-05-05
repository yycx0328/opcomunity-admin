using Opcomunity.Data.Entities;
using Opcomunity.Service.Models;
using System.Collections.Generic;

namespace Opcomunity.Service.Interface
{
    public interface IAnchorService
    {
        /// <summary>
        /// 推荐主播列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns></returns>
        List<AnchorModel> GetAnchorList(int pageIndex, int pageSize, string condition, string auth);

        AnchorModel GetAnchor(long userId);

        bool EditAnchor(long anchorId, string nickName, string description, int glamour, int cashRatio, int callRatio, bool isAuth,string categories);

        bool SetChatStatus(long anchorId, int chatStatus);

        bool SetBlackAnchor(long anchorId);

        List<AnchorCategoryRelationModel> GetAnchorCategoryRelation(long anchorId);

        bool DelPhoto(long id);
    }
}
