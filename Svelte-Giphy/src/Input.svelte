<script>
    import Images from "./Images.svelte";
    let queryText = '';
</script>

<input bind:value={queryText} placeholder="Something">
<Images bind:queryText limit=15 offset=0/>
