/*
The MIT License (MIT)

Copyright (c) 2007 - 2020 Microting A/S

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Microting.eForm.Infrastructure.Data.Entities
{
    public partial class options : BaseEntity
    {
        public int? NextQuestionId { get; set; }
        
        public int Weight { get; set; }
        
        public int WeightValue { get; set; }
        
        public int ContinuousOptionId { get; set; }
        
        [ForeignKey("question")]
        public int QuestionId { get; set; }
        
        public int OptionIndex { get; set; }
        
        public virtual questions Question { get; set; }
        
        public int? MicrotingUid { get; set; }
        
        public int DisplayIndex { get; set; }

        public virtual ICollection<option_translations> OptionTranslationses { get; set; }

        public async Task Create(MicrotingDbContext dbContext)
        {
            WorkflowState = Constants.Constants.WorkflowStates.Created;
            Version = 1;
            
            QuestionId = QuestionId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            dbContext.options.Add(this);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            dbContext.option_versions.Add(MapVersions(this));
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(MicrotingDbContext dbContext)
        {
            options option = await dbContext.options.FirstOrDefaultAsync(x => x.Id == Id);

            if (option == null)
            {
                throw new NullReferenceException($"Could not find option with Id: {Id}");
            }

            option.QuestionId = QuestionId;
            option.Weight = Weight;
            option.WeightValue = WeightValue;
            option.NextQuestionId = NextQuestionId;
            option.ContinuousOptionId = ContinuousOptionId;
            option.OptionIndex = OptionIndex;
            option.DisplayIndex = DisplayIndex;

            if (dbContext.ChangeTracker.HasChanges())
            {
                Version += 1;
                UpdatedAt = DateTime.UtcNow;

                dbContext.option_versions.Add(MapVersions(option));
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

        }

        public async Task Delete(MicrotingDbContext dbContext)
        {
            options option = await dbContext.options.FirstOrDefaultAsync(x => x.Id == Id);

            if (option == null)
            {
                throw new NullReferenceException($"Could not find option with Id: {Id}");
            }

            option.WorkflowState = Constants.Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                Version += 1;
                UpdatedAt = DateTime.UtcNow;

                dbContext.option_versions.Add(MapVersions(option));
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private option_versions MapVersions(options option)
        {
            return new option_versions
            {
                QuestionId = option.QuestionId,
                Weight = option.Weight,
                WeightValue = option.WeightValue,
                NextQuestionId = option.NextQuestionId,
                ContinuousOptionId = option.ContinuousOptionId,
                OptionIndex = option.OptionIndex,
                OptionId = option.Id,
                CreatedAt = option.CreatedAt,
                Version = option.Version,
                UpdatedAt = option.UpdatedAt,
                WorkflowState = option.WorkflowState,
                MicrotingUid = option.MicrotingUid,
                DisplayIndex = option.DisplayIndex
            };
        }
    }
}