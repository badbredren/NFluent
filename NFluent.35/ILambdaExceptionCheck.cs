﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ILambdaExceptionCheck.cs" company="">
// //   Copyright 2013 Rui CARVALHO, Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace NFluent
{
    /// <summary>
    /// Provides check methods to be executed on the exception raised by a given lambda/action.
    /// </summary>
    /// <typeparam name="TParent">The type of the parent.</typeparam>
    public interface ILambdaExceptionCheck<out TParent> : IHasParentCheck<TParent>,
        IMustImplementIForkableCheckWithoutDisplayingItsMethodsWithinIntelliSense
    {
        /// <summary>
        /// Checks that the message of the considered exception is correctly written.
        /// </summary>
        /// <param name="exceptionMessage">The expected exception message.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The code did not raised an exception of any type.</exception>
        ICheckLink<ILambdaExceptionCheck<TParent>> WithMessage(string exceptionMessage);

        /// <summary>
        /// Checks that a specific property of the considered exception has an expected value.
        /// </summary>
        /// <param name="propertyName">The name of the property to check on the considered exception.</param>
        /// <param name="propertyValue">The expected value for the property to check on the considered exception.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The code did not raised an exception of any type.</exception>
        ICheckLink<ILambdaExceptionCheck<TParent>> WithProperty(string propertyName, object propertyValue);

        /// <summary>
        /// Checks that a specific property of the considered exception has an expected value.
        /// </summary>
        /// <param name="propertyExpression">The Expression to retrieve the property Name</param>
        /// <param name="propertyValue">The expected value for the property to check on the considered exception.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <typeparam name="TException">The type of the Exception to use in the propertyExpression</typeparam>
        /// <exception cref="FluentCheckException">The code did not raised an exception of any type.</exception>
        ICheckLink<ILambdaExceptionCheck<TParent>> WithProperty<TException>(Expression<Func<TException, object>> propertyExpression, object propertyValue)
            where TException : Exception;
    }
}