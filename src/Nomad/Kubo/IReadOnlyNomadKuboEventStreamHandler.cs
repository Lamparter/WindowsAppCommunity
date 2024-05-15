﻿using System.Threading;
using System.Threading.Tasks;
using Ipfs;
using Ipfs.CoreApi;
using OwlCore.ComponentModel.Nomad;

namespace WinAppCommunity.Sdk.Nomad.Kubo;

/// <summary>
/// A shared interface for all read-only kubo based nomad storage.
/// </summary>
public interface IReadOnlyNomadKuboEventStreamHandler<in TEventEntryContent> : ISharedEventStreamHandler<Cid, KuboNomadEventStream, KuboNomadEventStreamEntry>
{
    /// <summary>
    /// The client to use for communicating with Ipfs.
    /// </summary>
    public ICoreApi Client { get; set; }

    /// <summary>
    /// Whether to use the cache when resolving Ipns Cids.
    /// </summary>
    public bool UseCache { get; set; }

    /// <summary>
    /// Applies an event stream update to this object without side effects.
    /// </summary>
    /// <param name="updateEvent">The update to apply without side effects.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the ongoing operation.</param>
    abstract Task ApplyEntryUpdateAsync(TEventEntryContent updateEvent, CancellationToken cancellationToken);
}