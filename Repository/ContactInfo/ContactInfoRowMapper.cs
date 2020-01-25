using Npgsql;

namespace Repository.ContactInfo
{
    public class ContactInfoRowMapper : AbstractRowMapper<ContactInfoEntity>
    {
        public const string TableName = "contact_info";

        private const int IdColumn = 0;
        private const int EmailColumn = 1;
        private const int PhoneColumn = 2;
        private const int MobileColumn = 3;
        private const int TitleColumn = 4;
        private const int GenderColumn  = 5;
        private const int NameColumn = 6;
        private const int SurnameColumn = 7;
        
        private const string IdColumnName = "id";
        private const string EmailColumnName = "email";
        private const string PhoneColumnName = "phone";
        private const string MobileColumnName = "mobile";
        private const string TitleColumnName = "title";
        private const string GenderColumnName = "gender";
        private const string NameColumnName = "name";
        private const string SurnameColumnName = "surname";
        

        public override NpgsqlCommand ToRow(NpgsqlCommand command, ContactInfoEntity contactInfo)
        {
            command.Parameters.AddWithValue(EmailColumnName, contactInfo.Email);
            command.Parameters.AddWithValue(PhoneColumnName, contactInfo.Phone);
            command.Parameters.AddWithValue(MobileColumnName, contactInfo.Mobile);
            command.Parameters.AddWithValue(TitleColumnName, contactInfo.Title);
            command.Parameters.AddWithValue(GenderColumnName, contactInfo.Gender);
            command.Parameters.AddWithValue(NameColumnName, contactInfo.Name);
            command.Parameters.AddWithValue(SurnameColumnName, contactInfo.Surname);
            command.Prepare();

            return command;
        }

        protected override ContactInfoEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new ContactInfoEntity(
                (ulong) resultSet.GetInt64(IdColumn),
                resultSet.GetString(EmailColumn),
                resultSet.GetString(PhoneColumn),
                resultSet.GetString(MobileColumn),
                resultSet.GetString(TitleColumn),
                resultSet.GetString(GenderColumn),
                resultSet.GetString(NameColumn),
                resultSet.GetString(SurnameColumn)
            );
        }
    }
}
