# generic-thrift-client
用于APIGate泛化调用Thrift服务


### 示例:
```csharp 
int thing = 10;

GenericTree input1 = new GenericTree();
input1.setName("thing");
input1.setParamType(TypeEnum.PRIMITIVE_TYPE);
input1.setThrfitType("I32");

List<GenericTree> inputGenericTrees = new List<GenericTree>
{
    input1
};

// 参数值
List<Object> inputVals = new List<object>();
inputVals.Add(thing);

//出参
GenericTree output = new GenericTree();
output.setParamType(TypeEnum.PRIMITIVE_TYPE);
output.setThrfitType("I32");
output.setName("returnModel");

string method = SERVICE_NAME + "testI32";

GenericNode genericNode = new GenericNode();
genericNode.setInputs(inputGenericTrees);
genericNode.setMethodName(method);
genericNode.setValues(inputVals);
genericNode.setOutput(output);

object obj = genericAnalyser.syncProcess(protocol, genericNode);

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
```

### 返回结果：
```json
{"returnModel":333}
```
            
