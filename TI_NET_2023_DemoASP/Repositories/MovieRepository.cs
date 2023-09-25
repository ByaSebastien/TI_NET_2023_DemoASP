using System.Data;
using TI_NET_2023_DemoASP.Models.Entities;

namespace TI_NET_2023_DemoASP.Repositories
{
    public class MovieRepository : BaseRepository<int, Movie>, IMovieRepository
    {
        public MovieRepository(IDbConnection connection) : base(connection, "Movie", "Movie_Id")
        {
        }

        protected override Movie Convert(IDataRecord record)
        {
            return new Movie()
            {
                Id = (int)record["Movie_Id"],
                Title = (string)record["Title"],
                Description = record["Description"] == DBNull.Value ? null : (string)record["Description"],
                ImageUrl = record["Image"] == DBNull.Value ? null : (string)record["Image"]
            };
        }

        public override Movie Create(Movie movie)
        {
            using(IDbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Movie(Title,Description,Image) " +
                                  "OUTPUT INSERTED.*" +
                                  "VALUES (@title,@description,@image)";
                GenerateParameter(cmd, "@title", movie.Title);
                GenerateParameter(cmd,"@description",movie.Description);
                GenerateParameter(cmd, "@image", movie.ImageUrl);

                OpenConnection(_connection);
                IDataReader reader = cmd.ExecuteReader();

                if(!reader.Read())
                {
                    throw new Exception();
                }
                Movie result = Convert(reader);

                _connection.Close();

                return result;

            }
        }

        public override bool Update(int id, Movie movie)
        {
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Movie " +
                                  "SET Title = @title, " +
                                      "Description = @description," +
                                      "Image = @image " +
                                  "WHERE Movie_Id = @id";
                GenerateParameter(cmd, "@title", movie.Title);
                GenerateParameter(cmd, "@description", movie.Description);
                GenerateParameter(cmd, "@image", movie.ImageUrl);
                GenerateParameter(cmd, "@id", id);

                OpenConnection(_connection);

                int nbLine = cmd.ExecuteNonQuery();

                _connection.Close();

                return nbLine == 1;
            }
        }
    }
}
