using System;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions.Test.Data;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DapperExtensions.Test.IntegrationTests.Sqlite
{
    [TestFixture]
    public class TimerFixture
    {
        private static int cnt = 1000;

        public class InsertTimes : SqliteBaseFixture
        {
            [Test]
            public async Task IdentityKey_UsingEntity()
            {
                Person p = new Person
                               {
                                   FirstName = "FirstName",
                                   LastName = "LastName",
                                   DateCreated = DateTime.Now,
                                   Active = true
                               };
                await Db.Insert(p);
                DateTime start = DateTime.Now;
                List<int> ids = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    Person p2 = new Person
                                    {
                                        FirstName = "FirstName" + i,
                                        LastName = "LastName" + i,
                                        DateCreated = DateTime.Now,
                                        Active = true
                                    };
                    await Db.Insert(p2);
                    ids.Add(p2.Id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }

            [Test]
            public async Task IdentityKey_UsingReturnValue()
            {
                Person p = new Person
                               {
                                   FirstName = "FirstName",
                                   LastName = "LastName",
                                   DateCreated = DateTime.Now,
                                   Active = true
                               };
                await Db.Insert(p);
                DateTime start = DateTime.Now;
                List<int> ids = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    Person p2 = new Person
                                    {
                                        FirstName = "FirstName" + i,
                                        LastName = "LastName" + i,
                                        DateCreated = DateTime.Now,
                                        Active = true
                                    };
                    var id = await Db.Insert(p2);
                    ids.Add(id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }

            [Test]
            public async Task GuidKey_UsingEntity()
            {
                Animal a = new Animal { Name = "Name" };
                await Db.Insert(a);
                DateTime start = DateTime.Now;
                List<Guid> ids = new List<Guid>();
                for (int i = 0; i < cnt; i++)
                {
                    Animal a2 = new Animal { Name = "Name" + i };
                    await Db.Insert(a2);
                    ids.Add(a2.Id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }

            [Test]
            public async Task GuidKey_UsingReturnValue()
            {
                Animal a = new Animal { Name = "Name" };
                await Db.Insert(a);
                DateTime start = DateTime.Now;
                List<Guid> ids = new List<Guid>();
                for (int i = 0; i < cnt; i++)
                {
                    Animal a2 = new Animal { Name = "Name" + i };
                    var id = await Db.Insert(a2);
                    ids.Add(id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }

            [Test]
            public async Task AssignKey_UsingEntity()
            {
                Car ca = new Car { Id = string.Empty.PadLeft(15, '0'), Name = "Name" };
                await Db.Insert(ca);
                DateTime start = DateTime.Now;
                List<string> ids = new List<string>();
                for (int i = 0; i < cnt; i++)
                {
                    var key = (i + 1).ToString().PadLeft(15, '0');
                    Car ca2 = new Car { Id = key, Name = "Name" + i };
                    await Db.Insert(ca2);
                    ids.Add(ca2.Id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }

            [Test]
            public async Task AssignKey_UsingReturnValue()
            {
                Car ca = new Car { Id = string.Empty.PadLeft(15, '0'), Name = "Name" };
                await Db.Insert(ca);
                DateTime start = DateTime.Now;
                List<string> ids = new List<string>();
                for (int i = 0; i < cnt; i++)
                {
                    var key = (i + 1).ToString().PadLeft(15, '0');
                    Car ca2 = new Car { Id = key, Name = "Name" + i };
                    var id = await Db.Insert(ca2);
                    ids.Add(id);
                }

                double total = DateTime.Now.Subtract(start).TotalMilliseconds;
                Console.WriteLine("Total Time:" + total);
                Console.WriteLine("Average Time:" + total / cnt);
            }
        }
    }
}