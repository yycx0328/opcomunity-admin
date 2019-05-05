using Opcomunity.Data.Entities;
using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opcomunity.Service.Implementations
{
    public class AnchorService: ServiceBase, IAnchorService
    {
        public bool EditAnchor(long anchorId, string nickName, string description, int glamour, int cashRatio, int callRatio, bool isAuth,string categories)
        {
            using (var context = base.NewContext())
            {
                var qUser = from u in context.TB_User
                            where u.Id == anchorId
                            select u;
                var user = qUser.SingleOrDefault();
                if (user == null)
                    return false;

                user.NickName = nickName;
                user.Description = description;

                var query = from a in context.TB_Anchor
                            where a.UserId == anchorId
                            select a;
                var anchor = query.SingleOrDefault();
                if (anchor != null)
                {
                    anchor.CashRatio = cashRatio;
                    anchor.CallRatio = callRatio;
                    anchor.Glamour = glamour;
                    anchor.IsAuth = isAuth;
                    if (isAuth)
                        anchor.AuthTime = DateTime.Now;
                    else
                        anchor.AuthTime = null;

                    var qRelation = from r in context.TB_AnchorCategoryRelation
                                    where r.AnchorId == anchorId
                                    select r;
                    var relations = qRelation.ToList();
                    if (relations != null && relations.Count > 0)
                        context.TB_AnchorCategoryRelation.RemoveRange(relations);

                    var arrCategory = categories.Split(',');
                    List<TB_AnchorCategoryRelation> list = new List<TB_AnchorCategoryRelation>();
                    foreach(var id in arrCategory)
                    {
                        list.Add(new TB_AnchorCategoryRelation() {
                            AnchorId = anchorId,
                            CategoryId = TypeHelper.TryParse(id,0),
                            CreateTime = DateTime.Now
                        });
                    }
                    context.TB_AnchorCategoryRelation.AddRange(list);

                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public AnchorModel GetAnchor(long userId)
        {
            using (var context = base.NewContext())
            {
                var query = from a in context.TB_Anchor
                            join u in context.TB_User
                            on a.UserId equals u.Id
                            join i in context.TB_AnchorIdentity
                            on a.UserId equals i.UserId
                            into g from i in g.DefaultIfEmpty()
                            where a.UserId == userId
                            select new AnchorModel
                            {
                                UserId = a.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                Avatar = u.Avatar,
                                ThumbnailAvatar = u.ThumbnailAvatar,
                                Description = u.Description,
                                Glamour = a.Glamour,
                                CallRatio = a.CallRatio,
                                CashRatio = a.CashRatio,
                                AuthTime = a.AuthTime,
                                IsAuth = a.IsAuth,
                                ApplyTime = a.ApplyTime,
                                IsBlack = a.IsBlack,
                                IdentityPositive = i.IdentityPositive,
                                UserPhotoItems = from up in context.TB_UserPhoto
                                                 where up.UserId == userId
                                                 orderby up.CreateTime descending
                                                 select new UserPhotoItem
                                                 {
                                                     Id = up.Id,
                                                     ImageWebPath = up.ImageWebPath,
                                                     ThumbnailPath = up.ThumbnailPath
                                                 }
                            };
                return query.SingleOrDefault();
            }
        }

        public List<AnchorModel> GetAnchorList(int pageIndex, int pageSize, string condition, string auth)
        {
            using (var context = base.NewContext())
            {
                var query = from a in context.TB_Anchor
                            join u in context.TB_User
                            on a.UserId equals u.Id
                            where !a.IsBlack
                            orderby a.ApplyTime descending
                            select new AnchorModel
                            {
                                UserId = a.UserId,
                                NickName = u.NickName, 
                                PhoneNo = u.PhoneNo,
                                Description = u.Description,
                                Glamour = a.Glamour,
                                CallRatio = a.CallRatio,
                                CashRatio = a.CashRatio,
                                AuthTime = a.AuthTime,
                                IsAuth = a.IsAuth,
                                ApplyTime = a.ApplyTime,
                                IsBlack = a.IsBlack
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition) || p.PhoneNo.Contains(condition));
                if (!string.IsNullOrEmpty(auth))
                {
                    var isAuth = TypeHelper.TryParse(auth, false);
                    query = query.Where(p => p.IsAuth == isAuth);
                }
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public bool SetChatStatus(long anchorId, int chatStatus)
        {
            using (var context = base.NewContext())
            {
                var query = from n in context.TB_NeteaseAccount
                            where n.UserId == anchorId
                            select n;
                var anchor = query.SingleOrDefault();
                if (anchor == null)
                    return false;
                anchor.ChatStatus = chatStatus;
                context.SaveChanges();
                return true;
            }
        }

        public bool SetBlackAnchor(long anchorId)
        {
            using (var context = base.NewContext())
            {
                var query = from n in context.TB_Anchor
                            where n.UserId == anchorId
                            select n;
                var anchor = query.SingleOrDefault();
                if (anchor == null)
                    return false;
                anchor.IsBlack = true;
                context.SaveChanges();
                return true;
            }
        }

        public List<AnchorCategoryRelationModel> GetAnchorCategoryRelation(long anchorId)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_AnchorCategory
                            join r in context.TB_AnchorCategoryRelation.Where(p=> p.AnchorId == anchorId)
                            on c.Id equals r.CategoryId
                            into g
                            from r in g.DefaultIfEmpty()
                            orderby c.SortId
                            where c.IsAvailable
                            select new AnchorCategoryRelationModel {
                                Id = c.Id,
                                Name = c.Name,
                                IsChecked = r!=null
                            };
                return query.ToList();
            }
        }

        public bool DelPhoto(long id)
        {
            using (var context = base.NewContext())
            {
                var query = from p in context.TB_UserPhoto
                            where p.Id == id
                            select p;
                var photo = query.SingleOrDefault();
                if (photo == null)
                    return false;
                context.TB_UserPhoto.Remove(photo);
                context.SaveChanges();
                return true;
            }
        }
    }
}
