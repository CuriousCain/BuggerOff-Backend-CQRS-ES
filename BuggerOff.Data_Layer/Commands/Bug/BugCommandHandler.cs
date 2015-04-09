﻿using Data_Layer.Contexts;
using Data_Layer.Events;
using Data_Layer.Interfaces;
using System;
using System.Linq;

namespace Data_Layer.Commands.Bug
{
    public class BugCommandHandler //TODO: Use async functions
    {
        private BugContext db;
        private BugEventHandler eventHandler;

        public BugCommandHandler(BugContext bugContext)
        {
            db = bugContext;
            eventHandler = new BugEventHandler();
        }

        public void Handle(OpenBug command)
        {
            var bug = command.NewBug;

            db.Add(bug);
            db.SaveChanges();

            eventHandler.Handle(new BugOpened(bug));
        }  

        public void Handle(CloseBug command)
        {
            var bug = db.Bugs.Single(x => x.ID == command.BugID);

            bug.Fixed = true;
            db.Update(bug);
            db.SaveChanges();
        }

        public void Handle(CloseMultipleBugs command)
        {
            foreach (int id in command.BugIDs)
            {
                var bug = db.Bugs.Single(x => x.ID == id);

                bug.Fixed = true;
                db.Update(bug);
            }

            db.SaveChanges();
        }
    }
}