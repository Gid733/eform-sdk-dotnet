/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 microting

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Linq;
using eFormShared;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace eFormSqlController
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class sites : BaseEntity
    {
        public sites()
        {
            this.cases = new HashSet<cases>();
            this.units = new HashSet<units>();
            this.site_workers = new HashSet<site_workers>();
            this.check_list_sites = new HashSet<check_list_sites>();
        }

//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int id { get; set; }
//
//        public DateTime? created_at { get; set; }
//
//        public DateTime? updated_at { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? microting_uid { get; set; }

//        public int? version { get; set; }
//
//        [StringLength(255)]
//        public string workflow_state { get; set; }

        public virtual ICollection<cases> cases { get; set; }

        public virtual ICollection<units> units { get; set; }

        public virtual ICollection<site_workers> site_workers { get; set; }

        public virtual ICollection<check_list_sites> check_list_sites { get; set; }


        public void Create(MicrotingDbAnySql dbContext)
        {
            workflow_state = Constants.WorkflowStates.Created;
            version = 1;
            created_at = DateTime.Now;
            updated_at = DateTime.Now;

            dbContext.sites.Add(this);
            dbContext.SaveChanges();

            dbContext.site_versions.Add(MapSiteVersions(this));
            dbContext.SaveChanges();
            
        }

        public void Update(MicrotingDbAnySql dbContext)
        {
            sites site = dbContext.sites.FirstOrDefault(x => x.id == id);

            if (site == null)
            {
                throw new NullReferenceException($"Could not find Site with id: {id}");

            }

            site.name = name;
            site.microting_uid = microting_uid;



            if (dbContext.ChangeTracker.HasChanges())
            {
                site.version += 1;
                site.updated_at = DateTime.Now;


                dbContext.site_versions.Add(MapSiteVersions(site));
                dbContext.SaveChanges();

            }
           
        }

        public void Delete(MicrotingDbAnySql dbContext)
        {
            sites site = dbContext.sites.FirstOrDefault(x => x.id == id);

            if (site == null)
            {
                throw new NullReferenceException($"Could not find Site with id: {id}");

            }

            site.workflow_state = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                site.version += 1;
                site.updated_at = DateTime.Now;


                dbContext.site_versions.Add(MapSiteVersions(site));
                dbContext.SaveChanges();

            }
        }
        
        
        private site_versions MapSiteVersions(sites site)
        {
            site_versions siteVer = new site_versions();
            siteVer.workflow_state = site.workflow_state;
            siteVer.version = site.version;
            siteVer.created_at = site.created_at;
            siteVer.updated_at = site.updated_at;
            siteVer.microting_uid = site.microting_uid;
            siteVer.name = site.name;

            siteVer.site_id = site.id; //<<--

            return siteVer;
        }
    }
}
