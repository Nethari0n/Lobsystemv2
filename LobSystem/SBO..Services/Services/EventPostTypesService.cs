using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SBO.Lobsystem.Domain.Data;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.ExtensionMethods;
using SBO.LobSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Services
{
    public class EventPostTypesService : IEventPostTypesService
    {
        readonly ApplicationDBContext _lobsContext;
        readonly ICreateService _iCreateService;
        public EventPostTypesService(ApplicationDBContext lobsContext, ICreateService iCreateService)
        {
            _lobsContext = lobsContext;
            _iCreateService = iCreateService;
        }

        #region Event

        public void AddEvent(Event events)
        {
            
                _lobsContext.Events.Add(events);
                _lobsContext.SaveChanges();
            
           
            //return FindEvent(events.CreateDate, events.Username);
        }

        //public Event FindEvent(DateTime time, string name) => _lobsContext.Events.Where(x => x.CreateDate == time && x.Username == name).AsNoTracking().FirstOrDefault();



        public List<Event> GetAllEvents() => _lobsContext.Events.Where(e => e.IsDeleted == false).Include(x => x.Type).AsNoTracking().ToList();

        public void DeleteEvent(int ID)
        {
            Event eventObj = _lobsContext.Events.Where(c => c.EventID == ID).FirstOrDefault();

            eventObj.IsDeleted = true;

            _lobsContext.Events.Update(eventObj);
            _lobsContext.SaveChanges();
        }

        public Event GetEventByID(int id)
        {
            
                return _lobsContext.Events.Where(c => c.EventID == id).AsNoTracking().FirstOrDefault();
            
        }

        #endregion

        #region Types

        public List<Types> GetAllTypes() => _lobsContext.Types.Where(e => e.IsDeleted == false).AsNoTracking().ToList();

        public List<Types> TypesPagination(int page, int totalItem) => _lobsContext.Types
            .Where(x => x.IsDeleted == false)
            .Paging(page, totalItem).AsNoTracking().ToList();

        public List<Types> SearchType(int page, int totalItem, string search) => _lobsContext.Types
            .Where(x => x.TypeName.Contains(search) || x.TypesID.ToString().Contains(search) && x.IsDeleted == false)
            .Paging(page, totalItem).AsNoTracking().ToList();

        public bool GetMultiRound(int id) => _lobsContext.Events.Where(x => x.EventID == id).Include(a => a.Type).Any(b => b.Type.MultipleRounds);

        public Types GetTypeByID(int id) => _lobsContext.Types.Where(x => x.TypesID == id).AsNoTracking().FirstOrDefault();

        public string GetTypeNameByID(int id)
        {
            
                string types = _lobsContext.Types.Where(x => x.TypesID == id).AsNoTracking().FirstOrDefault().TypeName;
                return types;
            
        }

        public void DeleteType(int ID)
        {
            Types type = _lobsContext.Types.Where(c => c.TypesID == ID).AsNoTracking().FirstOrDefault();

            type.IsDeleted = true;

            _lobsContext.Types.Update(type);
            _lobsContext.SaveChanges();
        }

        public bool TypeExists(int ID)
        {
            return _lobsContext.Types.AsNoTracking().Any(x => x.TypesID == ID) ? true : false;
        }

        public bool TypeExists(string TypeName)
        {
            var types = _lobsContext.Types.Where(x => x.TypeName == TypeName && x.IsDeleted == false).AsNoTracking().SingleOrDefault() ;
          

            if ( types == null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Post

        public async void AddPostFromList(List<Post> list, int id)
        {
            foreach ( Post posts in list )
                await _iCreateService.CreateEntity(posts);

        }

        public List<Post> GetAllPostByEventID(int id) => _lobsContext.Posts.Where(x => x.EventID == id && x.IsDeleted == false).AsNoTracking().ToList();



        public List<Post> GetAllPosts() => _lobsContext.Posts.Where(e => e.IsDeleted == false).AsNoTracking().ToList();


        public void DeletePost(int ID)
        {
            Post post = _lobsContext.Posts.Where(c => c.PostID == ID).AsNoTracking().FirstOrDefault();
            post.IsDeleted = true;

            _lobsContext.Posts.Update(post);
            _lobsContext.SaveChanges();
        }

        /// <summary>
        /// Sort out exsiting post from list and add new post to db
        /// </summary>
        /// <returns></returns>
        public void SortPosts(List<Post> list, int id)
        {
            for ( int i = 0; i < list.Count(); i++ )
            {
                if ( list[i].PostID != 0 ) { list.Remove(list[i]); i--; }
            }

            AddPostFromList(list, id);
        }

        /// <summary>
        /// Delete post from deleted post list
        /// </summary>
        /// <param name="list"></param>
        public void SortDeletedPosts(List<Post> list)
        {
            for ( int i = 0; i < list.Count(); i++ )
            {
                DeletePost(list[i].PostID);
            }
        }

        #endregion
    }
}
