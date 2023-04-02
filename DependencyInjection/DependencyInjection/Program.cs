// See https://aka.ms/new-console-template for more information
using Autofac;

ContainerBuilder builder = new();
builder.RegisterType<PopularityCalculator>().As<ICalculator>();
//builder.RegisterType<RankingMapper>().As<IRankingMapper>();
var container = builder.Build();

List<IStage> stages = new();
stages.Add(container.ResolveOptional<ICalculator>());
stages.Add(container.ResolveOptional<IMapper>());

foreach(var stage in stages)
{
    stage?.Process();
}

interface IStage
{
    void Process();
}

interface ICalculator : IStage
{

}

class PopularityCalculator : ICalculator
{
    public void Process()
    {
        // Process Something
    }
}

interface IMapper : IStage
{

}

class RankingMapper : IMapper
{
    public void Process()
    {
        // Process Something
    }
}