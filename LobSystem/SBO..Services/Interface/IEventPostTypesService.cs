using Lobsystem.Shared.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface IEventPostTypesService
    {
        #region Event

        Event AddEvent(Event events);

        Event FindEvent(DateTime time, string name);

        Event GetEvent(int id);

        List<Event> GetAllEvents();

        Event GetEventByID(int id);

        #endregion

        #region Types

        List<Types> GetAllTypes();

        List<Types> TypesPagination(int page, int totalItem);

        List<Types> SearchType(int page, int totalItem, string search);

        Types GetTypeByID(int id);

        string GetTypeNameByID(int id);

        bool GetMultiRound(int id);

        void DeleteType(int ID);

        #endregion

        #region Post

        void AddPostFromList(List<Post> list, int id);

        List<Post> GetAllPostByEventID(int id);

        List<Post> GetAllPosts();

        void DeletePost(int ID);

        void SortPosts(List<Post> list, int id);

        void SortDeletedPosts(List<Post> list);

        bool TypeExists(int ID);
        bool TypeExists(string TypeName);

        #endregion
    }
}
