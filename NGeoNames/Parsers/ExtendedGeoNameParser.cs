﻿using NGeoNames.Entities;
using System;
using System.Globalization;

namespace NGeoNames.Parsers
{
    /// <summary>
    /// Provides methods for parsing an <see cref="ExtendedGeoName"/> object from a string-array.
    /// </summary>
    public class ExtendedGeoNameParser : BaseParser<ExtendedGeoName>
    {
        private static readonly char[] csv = { ',' };

        /// <summary>
        /// Gets wether the file/stream has (or is expected to have) comments (lines starting with "#").
        /// </summary>
        public override bool HasComments
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the number of lines to skip when parsing the file/stream (e.g. 'headers' etc.).
        /// </summary>
        public override int SkipLines
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets the number of fields the file/stream is expected to have; anything else will cause a <see cref="ParserException"/>.
        /// </summary>
        public override int ExpectedNumberOfFields
        {
            get { return 19; }
        }

        /// <summary>
        /// Parses the specified data into an <see cref="ExtendedGeoName"/> object.
        /// </summary>
        /// <param name="fields">The fields/data representing an <see cref="ExtendedGeoName"/> to parse.</param>
        /// <returns>Returns a new <see cref="ExtendedGeoName"/> object.</returns>
        public override ExtendedGeoName Parse(string[] fields)
        {
            return new ExtendedGeoName
            {
                Id = int.Parse(fields[0]),
                Name = fields[1],
                ASCIIName = fields[2],
                AlternateNames = fields[3].Split(csv, StringSplitOptions.RemoveEmptyEntries),
                Latitude = double.Parse(fields[4], CultureInfo.InvariantCulture),
                Longitude = double.Parse(fields[5], CultureInfo.InvariantCulture),
                FeatureClass = fields[6],
                FeatureCode = fields[7],
                CountryCode = fields[8],
                AlternateCountryCodes = fields[9].Split(csv, StringSplitOptions.RemoveEmptyEntries),
                Admincodes = new[] { fields[10], fields[11], fields[12], fields[13] },
                Population = long.Parse(fields[14]),
                Elevation = fields[15].Length > 0 ? (int?)int.Parse(fields[15]) : null,
                Dem = int.Parse(fields[16]),
                Timezone = fields[17].Replace("_", " "),
                ModificationDate = DateTime.ParseExact(fields[18], "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
        }
    }
}
