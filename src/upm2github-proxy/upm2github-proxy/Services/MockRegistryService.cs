using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using upm2github_proxy.Json;
using upm2github_proxy.Models;

namespace upm2github_proxy.Services;

public class MockRegistryService : IRegistryService
{
    private List<SearchResultEntry> _entries = new List<SearchResultEntry>()
    {
        new()
        {
            Package = new Package()
            {
                Name = "com.apanloon.testpackage",
                DisplayName = "Apans Test Package",
                Description = "This package solves nothing.",
                DistTags = new Dictionary<string, string>()
                {
                    {"latest", "1.0.0"}
                },
                Maintainers = new List<Contact>()
                {
                    new() {Name = "Apan Loon", Email = "noemail@example.com"},
                    new() {Name = "Fake Dude", Email = "fake@example.com"}
                },
                Author = new Contact
                {
                    Name = "Apan Loon",
                    Email = "noemail@example.com"
                },
                ReadmeFilename = "README.md",
                Keywords = new List<string>()
                {
                    "unity",
                    "test"
                },
                License = "MIT",
                Time = new TimeInfo {Modified = DateTime.Parse("2022-03-17T00:25:16.023Z")},

                Versions = new Dictionary<string, string>
                {
                    {"1.0.0", "latest"}
                }

                //Links = new LinkList
                //{
                //    new() { Name = "npm", Url = "https://www.npmjs.com/package/yargs" },
                //    new() { Name = "homepage", Url = "http://yargs.js.org/" },
                //    new() { Name = "repository", Url = "https://github.com/yargs/yargs" },
                //    new() { Name = "bugs", Url = "https://github.com/yargs/yargs/issues" },
                //},
                //Publisher = new User { Name = "bcoe", Email = "ben@npmjs.com" },

                //Version = new SemVersion(6, 6, 6),

            },
            Flags = new Dictionary<string, bool>
            {
                {"unstable", true}
            },
            Local = false,
            Score = new Score
            {
                Final = 0.9237841281241451f,
                Detail = new ScoreDetail
                {
                    Quality = 0.9270640902288084f,
                    Popularity = 0.8484861649808381f,
                    Maintenance = 0.9962706951777409f
                }
            },
            SearchScore = 100000.914f
        }
    };

    private string _exampleSearchResult = @"
{
    ""objects"": [
        {
            ""package"": {
                ""name"": ""com.gemserk.upmgitpusher"",
                ""displayName"": ""UnityPackageManagerGitPusher"",
                ""description"": ""Just a simple tool integrated to Unity to publish your packages in a way UPM supports"",
                ""dist-tags"": {
                    ""latest"": ""0.0.16""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Ariel Coppes"",
                    ""email"": ""ariel.coppes@gmail.com"",
                    ""url"": ""https://blog.gemserk.com""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+ssh://git@github.com/acoppes/upmgitpusher.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/acoppes/upmgitpusher"",
                ""keywords"": [
                    ""git"",
                    ""tools"",
                    ""publish"",
                    ""package"",
                    ""upm""
                ],
                ""bugs"": {
                    ""url"": ""https://github.com/acoppes/upmgitpusher/issues""
                },
                ""time"": {
                    ""modified"": ""2020-04-26T04:13:39.253Z""
                },
                ""versions"": {
                    ""0.0.16"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.wayngroup.stm"",
                ""displayName"": ""Script Template Manager"",
                ""description"": ""A unity editor extension that allow you to create and manage your own script templates."",
                ""dist-tags"": {
                    ""latest"": ""0.0.5-alpha""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""script"",
                    ""c#"",
                    ""template""
                ],
                ""time"": {
                    ""modified"": ""2021-05-03T08:11:07.176Z""
                },
                ""versions"": {
                    ""0.0.5-alpha"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.andrewraphaellukasik.iopaths"",
                ""displayName"": ""IO Paths"",
                ""description"": ""Utility structures to help working with file paths in Unity."",
                ""dist-tags"": {
                    ""latest"": ""0.0.1""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Andrzej Rafał Łukasik"",
                    ""email"": ""andrew.r.lukasik@gmail.com"",
                    ""url"": ""https://github.com/andrew-raphael-lukasik""
                },
                ""readmeFilename"": """",
                ""time"": {
                    ""modified"": ""2020-11-05T18:51:58.362Z""
                },
                ""versions"": {
                    ""0.0.1"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.truongnguyentungduy.hierarchy-2"",
                ""displayName"": ""Hierarchy 2"",
                ""description"": ""Editor extension to improve hierarchy window. Makes the hierarchy more detail, but still clean and easy to organize."",
                ""dist-tags"": {
                    ""latest"": ""1.2.5""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Trương Nguyễn Tùng Duy""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""Editor"",
                    ""Hierarchy""
                ],
                ""time"": {
                    ""modified"": ""2022-02-26T19:46:45.197Z""
                },
                ""versions"": {
                    ""1.2.5"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.litefeel.openfileswithdefaultapp"",
                ""displayName"": ""OpenFilesWithDefaultApp"",
                ""description"": ""Open Files With Default App is just perfect Unity asset plugin to open file with system default Application."",
                ""dist-tags"": {
                    ""latest"": ""1.4.1""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""litefeel"",
                    ""email"": ""litefeel@gmial.com"",
                    ""url"": ""https://www.litefeel.com""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/litefeel/OpenFileWithDefaultApp.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/litefeel/OpenFileWithDefaultApp#readme"",
                ""keywords"": [
                    ""Editor"",
                    ""Open"",
                    ""File"",
                    ""Default"",
                    ""Application""
                ],
                ""bugs"": {
                    ""url"": ""https://github.com/litefeel/OpenFileWithDefaultApp/issues""
                },
                ""license"": ""MIT"",
                ""time"": {
                    ""modified"": ""2021-05-03T08:16:17.550Z""
                },
                ""versions"": {
                    ""1.4.1"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.github.sabresaurus.player-prefs-editor"",
                ""displayName"": ""PlayerPrefs Editor & Utilities"",
                ""description"": ""Provide an easy way to see what PlayerPrefs your game is using and change them at run-time. It also includes encryption support to protect your player prefs from casual hacking and has additional support for more data types."",
                ""dist-tags"": {
                    ""latest"": ""1.1.0""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""sabresaurus""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/sabresaurus/PlayerPrefsEditor.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/sabresaurus/PlayerPrefsEditor#readme"",
                ""keywords"": [
                    ""playerprefs"",
                    ""unity"",
                    ""editor"",
                    ""inspector""
                ],
                ""bugs"": {
                    ""url"": ""https://github.com/sabresaurus/PlayerPrefsEditor/issues""
                },
                ""time"": {
                    ""modified"": ""2020-05-08T17:37:58.381Z""
                },
                ""versions"": {
                    ""1.1.0"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.rodrigodzf.jackaudioforunity"",
                ""displayName"": ""JackAudioForUnity"",
                ""description"": ""Jack audio plugin for unity"",
                ""dist-tags"": {
                    ""latest"": ""1.1.0""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Rodrigo Diaz""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/rodrigodzf/Jack-Audio-For-Unity.git""
                },
                ""readmeFilename"": """",
                ""homepage"": ""https://github.com/rodrigodzf/Jack-Audio-For-Unity#readme"",
                ""keywords"": [
                    ""unity""
                ],
                ""bugs"": {
                    ""url"": ""https://github.com/rodrigodzf/Jack-Audio-For-Unity/issues""
                },
                ""license"": ""UNLICENSED"",
                ""time"": {
                    ""modified"": ""2021-02-09T18:01:17.513Z""
                },
                ""versions"": {
                    ""1.1.0"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""net.sanukin.uniplanemeshgenerator"",
                ""displayName"": ""UniPlaneMeshGnerator"",
                ""description"": ""Plane mesh generator for Unity"",
                ""dist-tags"": {
                    ""latest"": ""1.0.2""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""sanukin39"",
                    ""url"": ""https://github.com/sanukin39""
                },
                ""readmeFilename"": """",
                ""time"": {
                    ""modified"": ""2021-07-23T14:13:24.045Z""
                },
                ""versions"": {
                    ""1.0.2"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.4dage.spacetarget"",
                ""displayName"": ""4DAGE-SpaceTarget"",
                ""description"": ""SpaceTarget is a 4DAGE powered environment tracking feature that enables you to track and augment areas and spaces. By using a 4DKK 3D-Camera to create a database"",
                ""dist-tags"": {
                    ""latest"": ""1.0.3""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""4DAGE"",
                    ""email"": ""zhongwentong@cgaii.com"",
                    ""url"": ""https://www.4dkankan.com/#/developer/introduce""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""AreaTarget"",
                    ""SpaceTarget"",
                    ""AR""
                ],
                ""time"": {
                    ""modified"": ""2021-09-17T09:42:15.175Z""
                },
                ""versions"": {
                    ""1.0.3"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.grapefrukt.utils.usfxr"",
                ""displayName"": ""usfxr"",
                ""description"": ""quick prototype sound effects"",
                ""dist-tags"": {
                    ""latest"": ""0.0.3""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""grapefrukt"",
                    ""url"": ""https://github.com/grapefrukt/usfxr""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""audio""
                ],
                ""time"": {
                    ""modified"": ""2021-05-03T08:05:36.575Z""
                },
                ""versions"": {
                    ""0.0.3"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.littlebigfun.addressable-importer"",
                ""displayName"": ""Unity Addressable Importer"",
                ""description"": ""A simple rule based addressable asset importer."",
                ""dist-tags"": {
                    ""latest"": ""0.11.3""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Favo Yang"",
                    ""url"": ""https://github.com/favoyang""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/favoyang/unity-addressable-importer.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/favoyang/unity-addressable-importer#readme"",
                ""bugs"": {
                    ""url"": ""https://github.com/favoyang/unity-addressable-importer/issues""
                },
                ""license"": ""MIT"",
                ""time"": {
                    ""modified"": ""2022-02-06T15:51:18.150Z""
                },
                ""versions"": {
                    ""0.11.3"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.yontalane.layouttilemap"",
                ""displayName"": ""Layout Tilemap"",
                ""description"": ""Enables creation of prefab-based level layouts using 2D UnityEngine.Tilemap objects as blueprints."",
                ""dist-tags"": {
                    ""latest"": ""1.0.6""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Yontalane"",
                    ""email"": ""unitypackages@yontalane.com"",
                    ""url"": ""https://yontalane.com/""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""maps"",
                    ""tilemap"",
                    ""levels""
                ],
                ""time"": {
                    ""modified"": ""2022-02-14T04:57:55.420Z""
                },
                ""versions"": {
                    ""1.0.6"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.fairygui.gui"",
                ""displayName"": ""FairyGUI"",
                ""description"": ""A flexible UI framework for Unity"",
                ""dist-tags"": {
                    ""latest"": ""4.0.1000""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""FairyGUI"",
                    ""email"": ""support@fairygui.com"",
                    ""url"": ""https://www.fairygui.com/""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""ui""
                ],
                ""time"": {
                    ""modified"": ""2020-11-16T17:55:35.374Z""
                },
                ""versions"": {
                    ""4.0.1000"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.unity.project-auditor"",
                ""displayName"": ""Project Auditor"",
                ""description"": ""Project Auditor is an experimental static analysis tool that analyzes assets, settings, and scripts of the Unity project and produces a report containing: Code and Settings Diagnostics, the last BuildReport, and assets information. Note that this package is not officially supported by Unity and it is not on Unity's roadmap at this time."",
                ""dist-tags"": {
                    ""latest"": ""0.7.3-preview""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""readmeFilename"": ""README.md"",
                ""time"": {
                    ""modified"": ""2022-03-01T13:10:01.715Z""
                },
                ""versions"": {
                    ""0.7.3-preview"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.gwaredd.unium"",
                ""displayName"": ""Unium"",
                ""description"": ""API for external automation and tooling"",
                ""dist-tags"": {
                    ""latest"": ""1.1.7""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Gwaredd"",
                    ""email"": ""gwaredd@hotmail.com"",
                    ""url"": ""https://github.com/gwaredd/unium""
                },
                ""readmeFilename"": ""README.md"",
                ""license"": ""MIT"",
                ""time"": {
                    ""modified"": ""2022-02-08T11:31:57.607Z""
                },
                ""versions"": {
                    ""1.1.7"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.lavaleakgames.diplomata"",
                ""displayName"": ""Diplomata"",
                ""description"": ""Diplomata is a Unity multi language dialogues content management system and editor extension inspired by Twine, like Fungus and Yarn Spinner, but is not node based.\n\nDiplomata manage optionally other contents of a game like characters, inventory, quests, animations and sprites.\n\nIdealized for screenwriters, game designers, programmers and hobbyist writers, to configure and apply dialogues in any type of game."",
                ""dist-tags"": {
                    ""latest"": ""1.3.0""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Bruno Araujo"",
                    ""email"": ""bruno@lavaleakgames.com""
                },
                ""readmeFilename"": ""README.md"",
                ""keywords"": [
                    ""diplomata"",
                    ""narrative"",
                    ""dialogue"",
                    ""tree"",
                    ""rpg"",
                    ""adventure"",
                    ""multilanguage"",
                    ""language"",
                    ""novel"",
                    ""interactive"",
                    ""choices"",
                    ""editor"",
                    ""extension"",
                    ""system""
                ],
                ""license"": ""MIT"",
                ""time"": {
                    ""modified"": ""2021-05-03T08:16:26.715Z""
                },
                ""versions"": {
                    ""1.3.0"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""dev.f1yingbanana.sfizz-unity"",
                ""displayName"": ""Sfizz for Unity"",
                ""description"": ""A Unity3D MIDI player with instruments defined in sfz format, using sfizz as the underlying sampler."",
                ""dist-tags"": {
                    ""latest"": ""1.2.0""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""f1yingbanana"",
                    ""url"": ""https://flyblog.antigear.dev""
                },
                ""readmeFilename"": """",
                ""keywords"": [
                    ""sfz"",
                    ""sfizz"",
                    ""sampler"",
                    ""MIDI"",
                    ""synthesizer"",
                    ""music"",
                    ""audio""
                ],
                ""time"": {
                    ""modified"": ""2022-02-09T14:59:10.987Z""
                },
                ""versions"": {
                    ""1.2.0"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""dev.kyubuns.akyuiunityxd"",
                ""displayName"": ""AkyuiUnity.Xd"",
                ""description"": ""Generate Akyui from XD"",
                ""dist-tags"": {
                    ""latest"": ""1.3.4""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""kyubuns"",
                    ""email"": ""kyubuns@gmail.com"",
                    ""url"": ""https://kyubuns.dev/""
                },
                ""readmeFilename"": """",
                ""time"": {
                    ""modified"": ""2022-03-10T08:58:29.314Z""
                },
                ""versions"": {
                    ""1.3.4"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.oddworm.playmodeinspector"",
                ""displayName"": ""PlayMode Inspector"",
                ""description"": ""PlayMode Inspector allows you to write EditorGUI code inside your MonoBehaviour classes to display it inside the dedicated PlayMode Inspector window.\n\nOpen PlayMode Inspector from the Unity main menu under 'Window > Analysis > PlayMode Inspector.'"",
                ""dist-tags"": {
                    ""latest"": ""1.6.0""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""author"": {
                    ""name"": ""Peter Schraut"",
                    ""url"": ""http://console-dev.de""
                },
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/pschraut/UnityPlayModeInspector.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/pschraut/UnityPlayModeInspector#readme"",
                ""keywords"": [
                    ""unity"",
                    ""debug"",
                    ""analysis""
                ],
                ""bugs"": {
                    ""url"": ""https://github.com/pschraut/UnityPlayModeInspector/issues""
                },
                ""time"": {
                    ""modified"": ""2022-02-06T11:07:45.838Z""
                },
                ""versions"": {
                    ""1.6.0"": ""latest""
                }
            },
            ""flags"": {},
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        },
        {
            ""package"": {
                ""name"": ""com.nowsprinting.blender-like-sceneview-hotkeys"",
                ""displayName"": ""Blender-like SceneView Hotkeys"",
                ""description"": ""Select the viewing direction for a SceneView with the Blender-like hotkeys.\n\nIf your keyboard without a numpad, open preferences... | Blender-like SceneView Hotkeys, and turn on `Emulate Numpad`.\nHowever, in the Unity Editor, already assigned the `2` key. If you are using Unity 2019 or later, you can change the assignment with Shortcuts Manager.\n\nBlenderと同じホットキーでSceneViewの視線方向を切り替えられます。\n\nテンキーが無い場合は、Preferences... | Blender-like SceneView Hotkeys を開き、`Emulate Numpad`をonにすることでキーボードの数字キーで操作できます。\nただし、Unityエディタではすでに`2`キーに機能が割り当てられています。Unity 2019以降であれば Shortcuts Manager で割り当てを変更できます。"",
                ""dist-tags"": {
                    ""latest"": ""0.2.1""
                },
                ""maintainers"": [
                    {
                        ""name"": ""openupm"",
                        ""email"": ""openupm""
                    }
                ],
                ""repository"": {
                    ""type"": ""git"",
                    ""url"": ""git+https://github.com/nowsprinting/blender-like-sceneview-hotkeys.git""
                },
                ""readmeFilename"": ""README.md"",
                ""homepage"": ""https://github.com/nowsprinting/blender-like-sceneview-hotkeys"",
                ""bugs"": {
                    ""url"": ""https://github.com/nowsprinting/blender-like-sceneview-hotkeys/issues""
                },
                ""time"": {
                    ""modified"": ""2021-05-03T08:15:27.478Z""
                },
                ""versions"": {
                    ""0.2.1"": ""latest""
                }
            },
            ""flags"": {
                ""unstable"": true
            },
            ""local"": true,
            ""score"": {
                ""final"": 1,
                ""detail"": {
                    ""quality"": 1,
                    ""popularity"": 1,
                    ""maintenance"": 0
                }
            },
            ""searchScore"": 100000
        }
    ],
    ""total"": 20,
    ""time"": ""Wed, 16 Mar 2022 22:57:02 GMT""
}
";

    public SearchResult Search (
        string text = "",
        [Range(0, 250)] int size = 20,
        int from = 0,
        [Range(0f, 1f)] float quality = 1f,
        [Range(0f, 1f)] float popularity = 0f,
        [Range(0f, 1f)] float maintenance = 0f)
    {
        var data = File.ReadAllText("ExampleSearchResult.json");
        var result = JsonSerializer.Deserialize<SearchResult>(data, ApplicationJsonOptions.SerializerOptions)
                     ?? throw new HttpRequestException("Error searching for packages", null, HttpStatusCode.InternalServerError);
        
        _entries = result.Objects;

        if (from >= _entries.Count)
        {
            from = 0;
            size = 0;
        }

        if (from + size >= _entries.Count)
        {
            size = _entries.Count - from;
        }

        result = new SearchResult()
        {
            Objects = _entries.Take(new Range(from, size)).ToList(),
            Time = DateTimeOffset.Now
        };
        return result;
    }
}