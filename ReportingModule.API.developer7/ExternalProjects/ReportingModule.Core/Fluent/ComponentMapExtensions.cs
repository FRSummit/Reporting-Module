using System;
using System.Linq.Expressions;
using FluentNHibernate.Mapping;
using ReportingModule.Utility;

namespace ReportingModule.Core.Fluent
{
    public static class ComponentMapExtensions
    {
        public static void MapComponentWithPrefix<T, TComponent>(this ClassMap<T> map,
            Expression<Func<T, TComponent>> f)
        {
            map.Component(f).ColumnPrefix(MemberUtility.GetMemberInfo(f).Name);
        }

        public static void MapComponentWithPrefix<T, TComponent>(this ComponentPart<T> map,
            Expression<Func<T, TComponent>> f)
        {
            map.Component(f).ColumnPrefix(MemberUtility.GetMemberInfo(f).Name);
        }

        public static void MapComponentWithPrefix<T, TComponent>(this ComponentMap<T> map,
            Expression<Func<T, TComponent>> f)
        {
            map.Component(f).ColumnPrefix(MemberUtility.GetMemberInfo(f).Name);
        }
        
        public static void MapComponentWithPrefix<T, TComponent>(this JoinPart<T> map,
            Expression<Func<T, TComponent>> f)
        {
            map.Component(f).ColumnPrefix(MemberUtility.GetMemberInfo(f).Name);
        }
    }
}