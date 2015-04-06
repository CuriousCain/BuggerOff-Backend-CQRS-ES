using Data_Layer.Contexts;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace BuggerOff.Migrations
{
    [ContextType(typeof(Data_Layer.Contexts.BugContext))]
    public partial class initial : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201504062045242_initial";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
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