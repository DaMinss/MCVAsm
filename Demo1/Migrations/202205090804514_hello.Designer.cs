﻿// <auto-generated />
namespace Demo1.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class hello : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(hello));
        
        string IMigrationMetadata.Id
        {
            get { return "202205090804514_hello"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
