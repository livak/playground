using Orleans.Storage;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using System.IO;
using Newtonsoft.Json;

namespace IoT.FileStorage
{
    public class FileStorageProvider : IStorageProvider
    {
        string directory;
        public Logger Log { get; set; }

        public string Name { get; set; }

        public Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var fileInfo = GetFileInfo(grainType, grainReference);
            fileInfo.Delete();
            return TaskDone.Done;
        }

        public Task Close()
        {
            return TaskDone.Done;
        }

        public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            Name = name;
            directory = config.Properties["directory"];
            return TaskDone.Done;
        }

        public async Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var fileInfo = GetFileInfo(grainType, grainReference);
            if (!fileInfo.Exists) return;
            using (var steram = fileInfo.OpenText())
            {
                var json = await steram.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject(json, grainState.State.GetType());
                grainState.State = data;
            }
        }

        public Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var fileInfo = GetFileInfo(grainType, grainReference);
            var json = JsonConvert.SerializeObject(grainState.State);
            using (var stream = fileInfo.OpenWrite())
            using (var writer = new StreamWriter(stream))
            {
                return writer.WriteAsync(json);
            }

        }

        FileInfo GetFileInfo(string grainType, GrainReference grainReference)
        {
            var path = Path.Combine(directory, string.Format("{0}-{1}.json", grainType, grainReference.ToKeyString()));
            return new FileInfo(path);
        }
    }
}
