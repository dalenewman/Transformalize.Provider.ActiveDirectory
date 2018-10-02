using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using Transformalize.Configuration;
using Transformalize.Context;
using Transformalize.Contracts;
using Transformalize.Impl;
using Transformalize.Provider.ActiveDirectory;
using Transformalize.Providers.Trace;
using Process = Transformalize.Configuration.Process;

namespace UnitTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {

            var process = new Process {
                Name = "Test",
                ReadOnly = true,
                Connections = new List<Connection> {
                    new Connection {Name = "input", Provider = "activedirectory"},
                    new Connection {Name = "output", Provider = "internal"}
                },
                Entities = new List<Entity> {
                    new Entity {
                        Name = "Users",
                        Page=1,
                        Size=20,
                        Filter = new List<Filter> {
                            new Filter { Expression = "(&(mail=*)(objectClass=user)(objectCategory=person))"}
                        },
                        Fields = new List<Field> {
                            new Field { Name = "mail"},
                            new Field { Name = "title"},
                            new Field { Name="whenChanged", Type="datetime"}
                        }
                    }
                }
            };
            process.Check();

            Assert.AreEqual(0, process.Errors().Length);

            var logger = new TraceLogger(LogLevel.Debug);
            var context = new PipelineContext(logger, process, process.Entities[0]);
            var input = new InputContext(context);
            var reader = new ActiveDirectoryReader(input, new RowFactory(context.Entity.Fields.Count, true, false));
            var rows = reader.Read();

            var count = 0;
            foreach (var row in rows)
            {
                ++count;
                Trace.WriteLine(count + ". " + row.ToString());
            }

        }
    }
}
