<script>
  export let queryText = "";
  export let limit = 25;
  export let offset = 0;

  let apiKey = "YOUR_API_KEY";

  let gifs = [];
  let isLoaded = false;

  $: {
    function runIt() {
      isLoaded = false;

      let apiUrl =
        "https://api.giphy.com/v1/gifs/search?api_key=" +
        apiKey +
        "&q=" +
        queryText +
        "&limit=" +
        limit +
        "&offset=" +
        offset +
        "&rating=G&lang=en";

      fetch(apiUrl)
        .then(resp => resp.json())
        .then(function(data) {
          gifs = data.data;
          isLoaded = true;
        });
    }

    runIt();
  }
</script>

<style>
  .images {
    column-count: 3;
  }
  img {
    width: 100%;
    height: auto;
  }
</style>

<div class="container">
  <div class="images">
    {#if queryText}
      {#if !isLoaded}
        <h1>Loading...</h1>
      {:else}
        {#each gifs as gif}
          <img
            src={gif.images.fixed_height.url}
            alt={gif.title}
            width={gif.images.fixed_height.url.width}
            height={gif.images.fixed_height.url.height} />
        {/each}
      {/if}
    {/if}
  </div>
</div>
