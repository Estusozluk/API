using EstuSozluk.API.Models;
using EstuSozluk.API.Repositories;
using System;
using System.Linq;

namespace EstuSozluk.API.Services
{
    public class EntryService : IEntryService
    {

        EstuSozlukDbContext _EstuSozlukDbContext;

        public EntryService(EstuSozlukDbContext EstuSozlukDbContext)
        {
            _EstuSozlukDbContext = EstuSozlukDbContext;
        }

        public object GetAllEntriesByUserName(string username)
        {
            EstuSozlukDbContext Context = _EstuSozlukDbContext;

            var sorgu = Context.Set<User>().Where(e => e.username == username)
                .Select(e => new
                {
                    e.username,
                    e.email,
                    e.userrole,
                    Followers = e.Followed.Select(e => e.follower).ToList(),
                    Following = e.Following.Select(e => e.followed).ToList(),
                }).First();

            Console.WriteLine(Context.Set<User>().Select(e => e.Entries).Count());

            return new
            {
                sorgu.username,
                sorgu.email,
                sorgu.userrole,
                sorgu.Followers,
                sorgu.Following,
                FollowerCount = sorgu.Followers.Count,
                FollowedCount = sorgu.Following.Count,
            };



            //return Context.Set<User>().Where(e => e.username == username)
            //    .Select(e => new
            //    {
            //        e.username,
            //        e.email,
            //        e.userrole,
            //        Followers = e.Followed.Select(e => e.follower).ToList(),
            //        Following = e.Following.Select(e => e.followed).ToList(),
            //    }).First();

            //return Context.Users.Where(e => e.username == username)
            //    .Select(e => new
            //    {
            //        e.username,
            //        e.email,
            //        e.userrole,
            //        Followers = e.Followed.Select(e => e.follower).ToList(),
            //        Following = e.Following.Select(e => e.followed).ToList(),
            //    }).First();

            // Eager Load:

            // return Context.Users.Include(t => t.Entries).ToList();



            //Lazy Load:

            //User user = Context.Users.ToList()[0];

            //Console.WriteLine(user.Entries.Count);

            //return user.username;


            // Explict Loading: 
            //var user = Context.Users
            //    .Single(b => b.username == username);

            //Console.WriteLine(user.Entries.FirstOrDefault());

            //Context.Entry(user)
            //    .Collection(b => b.Entries)
            //    .Load();

            // return user;


            //return from users in Context.Users
            //       join entries in Context.Entries
            //       on users.username equals entries.entryuser
            //       select new
            //       {
            //           users.username,
            //           users.email,
            //           users.userrole,
            //           entries.titlename,
            //           entries.content,
            //           entries.edittade,
            //           entries.writedate,
            //       };
        }
    }
}
