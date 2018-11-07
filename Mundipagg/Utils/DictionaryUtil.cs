﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mundipagg.Utils
{
    /// <summary>
    /// Dictionary utility
    /// </summary>
    public static class DictionaryUtil
    {
        #region Public Methods

        /// <summary>
        /// Cast object to dictionary
        /// </summary>
        /// <param name="source">Object to cast</param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this object source)
        {
            if (source == null)
                ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                AddPropertyToDictionary(property, source, dictionary);
            return dictionary;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Add identified property to dictionary
        /// </summary>
        /// <param name="property">Property info</param>
        /// <param name="source">Object to extract value</param>
        /// <param name="dictionary">Dictionary to add value</param>
        private static void AddPropertyToDictionary(PropertyDescriptor property, object source, Dictionary<string, string> dictionary)
        {
            object value = property.GetValue(source);
            if (value != null)
            {
                if (value is Enum)
                {
                    value = ((Enum)value).GetEnumMember();
                }
                dictionary.Add(property.Name.ToSnakeCase(), value.ToString());
            }
        }

        /// <summary>
        /// Throw exception when source argument is null
        /// </summary>
        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");
        }

        #endregion Private Methods
    }
}