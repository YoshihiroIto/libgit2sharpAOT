using LibGit2Sharp;

var repoPath = args.Length > 0 ? args[0] : @"C:\Users\yoi\Documents\Caphe";

using var repo = new Repository(repoPath);

var commits = repo.Commits
    .QueryBy(new CommitFilter
    {
        SortBy = CommitSortStrategies.Time | CommitSortStrategies.Topological, IncludeReachableFrom = repo.Refs
    }).Take(5).ToArray();

var latestCommit = commits.First();

foreach (var commit in commits)
{
    Console.WriteLine("---------------------------------------------------------------------");
    Console.WriteLine(commit.MessageShort);
    Console.WriteLine(commit.Sha);
    Console.WriteLine("");

    foreach (var c in repo.Diff.Compare<Patch>(latestCommit.Tree, commit.Tree))
        Console.WriteLine(c.Patch);
}