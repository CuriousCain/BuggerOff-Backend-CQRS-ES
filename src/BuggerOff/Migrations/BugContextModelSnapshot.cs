using Data_Layer.Contexts;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace BuggerOff.Migrations
{
    [ContextType(typeof(Data_Layer.Contexts.BugContext))]
    public class BugContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Data_Layer.Models.Bug", b =>
                    {
                        b.Property<string>("Description");
                        b.Property<bool>("Fixed");
                        b.Property<int>("ID")
                            .GenerateValueOnAdd();
                        b.Key("ID");
                    });
                
                return builder.Model;
            }
        }
    }
}