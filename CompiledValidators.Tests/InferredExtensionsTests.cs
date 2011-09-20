﻿using System.Linq;
using Moq;
using NUnit.Framework;

namespace CompiledValidators.Tests
{
    [TestFixture]
    public class InferredExtensionsTests
    {
        private static readonly IValidator Validator = Mock.Of<IValidator>(m => m.IsValid(It.IsAny<TestType>()) == true);

        [Test]
        public void CanInferIsValid()
        {
            Assert.IsTrue(Validator.IsValidInferred(new TestType()));
        }

        [Test]
        public void CanInferValidateToFirstError()
        {
            Assert.IsNull(Validator.ValidateToFirstErrorInferred(new TestType()));
        }

        [Test]
        public void CanInferValidate()
        {
            Assert.IsFalse(Validator.Validate(new TestType()).Any());
        }

        private class TestType { }
    }
}
