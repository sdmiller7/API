using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceClient.Web;
using BitHiker.Api.Models;
using System.Security.Cryptography;

namespace BitHiker.Api.Populator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Populator("http://bithikerapi.azurewebsites.net/api", 35.779943, -78.661423).Start(10000);
        }
    }

    public class Populator
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Url { get; set; }
        private List<string> UserIds { get; set; }
        private Random random;
        private JsonServiceClient _client;

        public Populator(string url, double latitude, double longitude)
        {
            Url = url;
            Latitude = latitude;
            Longitude = longitude;
            _client = new JsonServiceClient(Url);
        }

        public void Start(int simulatedExchanges)
        {
            random = new Random(DateTime.UtcNow.Millisecond);
            GenerateUserIds();

            for (var i = 0; i < simulatedExchanges; i++)
            {
                var exchangePair = GenerateExchangePair();

                _client.Post(exchangePair[0]);
                _client.Post(exchangePair[1]);

                Console.WriteLine("{0} complete", i+1);
            }
        }

        private void GenerateUserIds()
        {
            UserIds = new List<string>(new string[]{
                "e434f686-160e-4a1d-b75e-66c1b492f776",
                "44c6bd21-d1bb-4185-9927-44dde0a674c1",
                "a48eaf30-66c2-4979-959c-02958f569746",
                "d498abe9-734f-4ca5-a85a-0b432610fcef",
                "9ba3dc4e-6aae-4e7f-9210-04771517c981",
                "2a0f2cd7-19c2-4b2c-9630-dcb5581497cc",
                "67e547d8-461f-4b40-b31f-fa2f610e5530",
                "f8184f48-5827-479f-aa94-1df06619251d",
                "2fc6f52e-9fbd-4cde-8afe-9db86c4a8030",
                "f71d27cc-cf2e-4130-bfec-2ffa3472cb86",
                "182d94d5-507f-4ebb-9a75-511296abe6e4",
                "9f9cead3-4851-44d5-87c0-7c1c14e43a89",
                "4a215f92-83f6-4f51-a494-c5054650abf1",
                "6e50ab36-8be9-41f5-9545-5a882d0a0912",
                "caed7be6-08a2-478c-9ccf-a2b652bccc95",
                "eafc4118-13b9-4d04-ab56-f79c9799dabf",
                "098c4566-b79b-4b31-b190-115f2cb839f3",
                "136b520f-ce74-44a2-adb8-b5c6fd2248ed",
                "92c6bf4e-01aa-491d-b3bc-ae410dacb24e",
                "ff254176-786d-4d84-bcc1-041e2eaafa11",
                "388e23a9-e6c2-4f3f-a4ff-cf6fa2c5b76f",
                "36b9f428-fcf2-4c51-908a-b8fb382e8ae7",
                "c1cbf0ed-96c5-45f1-9d1a-00db6e0173fb",
                "b4efbeb0-9c08-4bfc-97d1-1291959be954",
                "2aadbd64-fd79-47a1-a4e7-1b829eb22d7f",
                "d56066f5-31cc-4109-ad95-e69d9e2c0e99",
                "a1ebf53f-eb16-4c3b-9c92-0bad202be14a",
                "495441db-f7e0-4a8c-b7e7-bb58d3c1a140",
                "e67ba541-9521-42b5-a012-1eb81210aeae",
                "0f8321cc-41d2-44ad-8a0b-ddc12b0f5579",
                "0fb0ade9-3822-4945-9729-7e9de5d0ff0e",
                "bdd122b3-39ff-4ccd-bb1a-06d29009ca39",
                "cd1a6c79-68bc-48f0-8050-9b04e006b5d5",
                "9640db54-db50-45d5-8d36-c9a05c65fa19",
                "b7bf74f1-d223-4089-8570-23ff3964034c",
                "432d5905-eaef-4f13-8852-f29fa25110a3",
                "e4425fa7-5382-47fb-8a87-47af81345566",
                "44894e13-25ec-4b01-80c7-fcbb16ef9f69",
                "6b5dc364-fc0d-4977-9a22-2736b2874de8",
                "9ac60fd3-8163-4f2f-a2e0-bd84ff88c859",
                "5168b05d-95ec-4301-85a7-69dfd317479e",
                "7e1a3325-58b9-4e92-ac75-bd934665629f",
                "63ad169c-0b2a-4b4a-8371-a262d1628506",
                "721cde20-0ad4-4fc5-bdab-3951e67c0804",
                "7b0479f8-7112-4895-b13a-6d8314d0e9ff",
                "4ddeb41c-c2bf-4a3d-83f4-a3e1925fedfe",
                "4335a0ce-c642-4f1e-acc7-acbc2c3ec7b8",
                "14f13d4f-34f6-4830-8b93-49bce5b13c9d",
                "e9058680-494b-4fb0-9ece-0cb443774e41",
                "b3a96de6-04a7-4434-8f13-8a8695a97088",
                "13c46cf4-d8e0-4d8e-8a60-9dea63d794c1",
                "9147d3e2-7d73-409f-a550-2b407ae56df9",
                "5c10b090-22fb-4819-9c84-5632ac586632",
                "d4ee8c89-de0b-4bf4-a24e-4de1f7b0ba84",
                "52cec436-5eba-42ad-bacc-526284d8f221",
                "40332cd7-ed07-4f1b-a01d-d30b3d0d305c",
                "761f852b-379f-4b87-9837-b8503643f627",
                "e7b27516-3776-4c64-9fad-a81c4d4e6977",
                "6c73c44e-af2a-4b34-9728-0be3eb3c5fe3",
                "acc4de7d-1c46-4d3d-a3b1-149e75542ada",
                "e08299b1-233a-44eb-a290-5cebb106a726",
                "bd6a0415-b6aa-49aa-8654-128a8bfc4b43",
                "36fef7f1-e7e6-4e41-a429-79dd0c9b72a7",
                "2f1e69b8-edc5-49a0-9c2c-9b3d4c844767",
                "772428cf-6ac2-476b-b649-6960ff19319e",
                "cb54c927-9ad1-4de9-8a57-3f44d7ab5ac0",
                "4e271ecd-3aee-44ab-bcdc-ac89f941e107",
                "145ca213-fa2f-49c0-b8f1-234ea66e329c",
                "54c0d69f-0bba-45b0-a7bd-9ffd093f0699",
                "764d0761-68f6-42f1-a051-c2ee748a75a7",
                "eb6c1371-7cab-481a-a1fe-7b10770ac76c",
                "d21b9a43-68c1-47d5-9a94-778a79c37bfe",
                "e1af13f6-549b-43a0-8c18-ab918d9134f6",
                "dafa5351-f2c0-4a21-82e9-7478e782788b",
                "383b5cf1-610f-4dfb-a40d-ca7248efbce5",
                "6c78e19f-407d-400d-91f7-5ffee46b3ae4",
                "2b1d022b-e288-4d30-95ab-3ab35c8f8161",
                "e82d6532-5bc5-47e4-9ccb-a87eefd0e794",
                "5c613eda-5f85-493e-bd9a-51db21b3e46f",
                "52d6ec66-62bb-4121-9613-14b24a861c8a",
                "35e51d0c-9f63-485f-9ae6-d2bbdc75d9a0",
                "8dc0336a-3d7e-4162-a18f-5c8f6dea9af4",
                "c097bb29-96ff-4a62-b107-c6fcf431dc7c",
                "0a967e31-d2b4-4bcc-a84c-f2c2ff646cfd",
                "cc4d9e47-ead3-404c-9b64-dca84ebb01b2",
                "0850209b-76f1-4645-b74c-bc93a9c6e169",
                "ade456b0-a5a1-4dd6-87ee-083755c9188a",
                "9a54fbb6-c32e-4e5d-8b79-25d466006cbf",
                "3b91f21f-2ceb-4d6a-8a6b-5ef0cbd511e8",
                "98e8fd7c-70ea-4c7f-9fae-2f5039b942ad",
                "6b822c73-e834-47bf-8bc1-f37b6f9407cd",
                "9a61e910-be73-45ec-8fd7-e9ed075d0170",
                "458898db-3803-4837-a91d-3e747ffe4cf4",
                "7157d0d2-f137-410e-8492-b140d94dbfea",
                "0bfa5554-8446-4199-88c1-47c290987215",
                "38169324-ac6b-44fa-9046-ad918f4a2164",
                "0997755b-e496-4e3a-ae47-6c45b19c8230",
                "c69178be-124b-4a58-a940-9051c8cedaa3",
                "b533fae9-9221-4d86-b62d-03218622a159",
                "0c75c27c-e57a-4dd0-ae4d-ab962e68f59d"});

            return;

            for (var i = 0; i < 1000; i++)
            {
                UserIds.Add(Guid.NewGuid().ToString());
            }
        }

        private string GetUserId(string ignoreId = "")
        {
            var upperLimit = UserIds.Count;

            var randomNumber = random.Next(0, upperLimit - 1);
            while (UserIds[randomNumber] == ignoreId)
            {
                randomNumber = random.Next(0, upperLimit - 1);
            }

            return UserIds[randomNumber];
        }

        private double GetLatitude()
        {
            var positive = random.Next(0, 1) == 1;
            var randomDouble = random.NextDouble();
            return positive
                       ? (Latitude + randomDouble)
                       : (Latitude - randomDouble);
        }

        private double GetLongitude()
        {
            var positive = random.Next(0, 1) == 1;
            var randomDouble = random.NextDouble();
            return positive
                       ? (Longitude + randomDouble)
                       : (Longitude - randomDouble);
        }

        private PrototypeExchange[] GenerateExchangePair()
        {
            var user1 = GetUserId();
            var user2 = GetUserId(user1);
            var latitude = GetLatitude();
            var longitude = GetLongitude();

            var user1Exchange = new PrototypeExchange()
                {
                    HorizontalAccuracy = random.NextDouble() * random.Next(1, 120),
                    Latitude = latitude,
                    Longitude = longitude,
                    UserId = user1,
                    TargetUserId = user2,
                    LocationFreshnessInSeconds = random.NextDouble() * random.Next(1, 300)
                };
            var user2Exchange = new PrototypeExchange()
                {
                    HorizontalAccuracy = random.NextDouble() * random.Next(1, 120),
                    Latitude = latitude,
                    Longitude = longitude,
                    UserId = user2,
                    TargetUserId = user1,
                    LocationFreshnessInSeconds = random.NextDouble() * random.Next(1, 300)
                };

            return new[]
                {
                    user1Exchange,
                    user2Exchange
                };
        }
    }
}
