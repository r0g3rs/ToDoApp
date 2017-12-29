using NUnit.Framework;
using System.Transactions;
using ToDoApp.Business;
using ToDoApp.Model;

namespace ToDoApp.Tests
{
    [TestFixture]
    public class BLToDoTest
    {
        #region Properties
        BLToDo _BLToDo;
        ToDoItem entityToDo;
        TransactionScope trans = null;
        #endregion

        #region SetUp
        [SetUp]
        public void Init()
        {
            //Business
            _BLToDo = new BLToDo();

            //Entidade
            entityToDo = new ToDoItem();
            entityToDo.Task = "Terminar desafios";
            entityToDo.Done = false;

            trans = new TransactionScope(TransactionScopeOption.Required);
        }

        [TearDown]
        public void Cleanup()
        {
            _BLToDo = null;
            entityToDo = null;
            trans.Dispose();
        }
        #endregion

        #region Methods
        [Test]
        public void CreateToDoTest()
        {
            var result = _BLToDo.CreateToDo(entityToDo);

            Assert.NotNull(result.ID);
        }

        [Test]
        public void GetAllToDoItemsTest()
        {
            var result = _BLToDo.CreateToDo(entityToDo);

            Assert.AreEqual(1, _BLToDo.RowCountToDo());

            var allResult = _BLToDo.GetAllToDoItems();
            Assert.IsNotNull(allResult);
        }

        [Test]
        public void GetToDoTest()
        {
            var result = _BLToDo.CreateToDo(entityToDo);

            Assert.AreEqual(1, _BLToDo.RowCountToDo());

            var resultToDo = _BLToDo.GetToDo(result.ID);
            Assert.IsNotNull(resultToDo);
        }

        [Test]
        public void UpdateToDoTest()
        {
            var result = _BLToDo.CreateToDo(entityToDo);

            Assert.AreEqual(1, _BLToDo.RowCountToDo());

            entityToDo = _BLToDo.GetToDo(entityToDo.ID);
            entityToDo.Task = "Alterado";
            _BLToDo.UpdateToDo(entityToDo);

            Assert.AreEqual(1, _BLToDo.RowCountToDo());
            Assert.AreEqual("Alterado", _BLToDo.GetToDo(entityToDo.ID).Task);
        }

        [Test]
        public void DeleteToDoTest()
        {
            var result = _BLToDo.CreateToDo(entityToDo);

            Assert.AreEqual(1, _BLToDo.RowCountToDo());

            _BLToDo.DeleteToDo(entityToDo.ID);
            Assert.AreEqual(0, _BLToDo.RowCountToDo());
        } 
        #endregion
    }
}
