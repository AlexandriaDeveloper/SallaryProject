#nullable disable

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class Specifications<T> : ISpecifications<T>

    {
        public Specifications()
        {

        }
        public Specifications(Expression<Func<T, bool>> criteria)
        {
            this.Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, bool>>> Criteries { get; } = new List<Expression<Func<T, bool>>>();
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddCriteries(Expression<Func<T, bool>> crtieriaExpression)
        {
            Criteries.Add(crtieriaExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orederByExpression)
        {
            this.OrderBy = orederByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orederByDesExpression)
        {
            this.OrderByDescending = orederByDesExpression;
        }

        protected void ApplyPagination(int skip, int take)
        {
            this.Skip = skip;
            this.Take = take;
            IsPagingEnabled = true;
        }
    }
}