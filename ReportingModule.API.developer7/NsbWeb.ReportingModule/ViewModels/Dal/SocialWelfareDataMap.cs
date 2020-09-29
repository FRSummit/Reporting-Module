﻿using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class SocialWelfareDataMap : ComponentMap<SocialWelfareData>
    {
        public SocialWelfareDataMap()
        {
            Map(x => x.Target);
            Map(x => x.Actual);
            Map(x => x.Comment);
            Map(x => x.DateAndAction);
        }
    }
}