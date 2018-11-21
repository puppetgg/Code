using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IEnumerator_Example
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        public Course(String name)
        {
            Name = name;
        }
        public String Name { get; } = string.Empty;
    }

    public class CourseCollection : IEnumerable<Course>
    {
        public CourseCollection()
        {
            arr_Course = new Course[] 
            {
                new Course("语文"),
                new Course("数学"),
                new Course("英语"),
                new Course("体育")
            };
        }

        private Course[] arr_Course;

        public Course this[int index] => arr_Course[index];

        public int Count => arr_Course.Length;

        public IEnumerator<Course> GetEnumerator()
        {
            return new CourseEnumerator(this);
        }

        #region 实现 IEnumerable<T>

        private sealed class CourseEnumerator : IEnumerator<Course>
        {
            private readonly CourseCollection courseCollection;
            private int index;

            internal CourseEnumerator(CourseCollection courseCollection)
            {
                this.courseCollection = courseCollection;
                index = -1;
            }

            public Course Current
            {
                get { return courseCollection[index]; }
            }

            bool IEnumerator.MoveNext()
            {
                index++;
                return (index < courseCollection.Count);
            }

            void IEnumerator.Reset()
            {
                index = -1;
            }

            #region 其他

            object IEnumerator.Current
            {
                get { return Current; }
            }

            void IDisposable.Dispose() { }

            #endregion
        }

        #endregion

        #region 其他

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
