<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <!-- <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo">
    <h1 class="my-5 bg-primary text-secondary p-3 rounded d-flex align-items-center">
      <span class="mx-2 text-secondary">Vue 3 Starter</span>
    </h1> -->
    <div class="container">
      <div class="row masonryholder">
        <div class="card-columns">
          <div class="card">
            <img src="https://images.unsplash.com/photo-1472214103451-9374bd1c798e?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MzF8fG5hdHVyZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">
                Card title that wraps to a new line
              </h5>
              <p class="card-text">
                This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
              </p>
            </div>
          </div>
          <div class="card p-3">
            <blockquote class="blockquote mb-0 card-body">
              <p>A well-known quote, contained in a blockquote element.</p>
              <footer class="blockquote-footer">
                <small class="text-muted">
                  Someone famous in <cite title="Source Title">Source Title</cite>
                </small>
              </footer>
            </blockquote>
          </div>
          <div class="card">
            <img src="https://images.unsplash.com/photo-1439853949127-fa647821eba0?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTl8fG5hdHVyZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">
                Card title
              </h5>
              <p class="card-text">
                This card has supporting text below as a natural lead-in to additional content.
              </p>
              <p class="card-text">
                <small class="text-muted">Last updated 3 mins ago</small>
              </p>
            </div>
          </div>
          <div class="card bg-primary text-white text-center p-3">
            <blockquote class="blockquote mb-0">
              <p>A well-known quote, contained in a blockquote element.</p>
              <footer class="blockquote-footer text-white">
                <small>
                  Someone famous in <cite title="Source Title">Source Title</cite>
                </small>
              </footer>
            </blockquote>
          </div>
          <div class="card text-center">
            <div class="card-body">
              <h5 class="card-title">
                Card title
              </h5>
              <p class="card-text">
                This card has a regular title and short paragraphy of text below it.
              </p>
              <p class="card-text">
                <small class="text-muted">Last updated 3 mins ago</small>
              </p>
            </div>
          </div>
          <div class="card">
            <img src="https://images.unsplash.com/photo-1469474968028-56623f02e42e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1053&q=80" class="card-img" alt="...">
          </div>
          <div class="card p-3 text-right">
            <blockquote class="blockquote mb-0">
              <p>A well-known quote, contained in a blockquote element.</p>
              <footer class="blockquote-footer">
                <small class="text-muted">
                  Someone famous in <cite title="Source Title">Source Title</cite>
                </small>
              </footer>
            </blockquote>
          </div>
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">
                Card title
              </h5>
              <p class="card-text">
                This is another card with title and supporting text below. This card has some additional content to make it slightly taller overall.
              </p>
              <p class="card-text">
                <small class="text-muted">Last updated 3 mins ago</small>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }

//   body {
//   margin: 0;
//   padding: 1rem;
// }
//   .masonryholder {
//   margin: 0;
//   padding: 1rem;
// }

// .masonry-with-columns {
//   columns: 4 200px;
//   column-gap: 1rem;
//   div {
//     width: 150px;
//     margin: 0 1rem 1rem 0;
//     display: inline-block;
//     width: 100%;
//     text-align: center;
//     font-family: system-ui;
//     font-weight: 900;
//     font-size: 2rem;
//   }
//   @for $i from 1 through 36 {
//     div:nth-child(#{$i}) {
//       $h: (random(400) + 100) + px;
//       height: $h;
//       line-height: $h;
//     }
//   }
// }
// .testing{
//   position: relative;
// }

// .masonryholder{
//   column-count: 4;
//   column-gap: 1rem;
//   border: 1px solid red
// }
// .masonryblocks{
//   display: inline-block;
//   padding: 1rem;
//   margin: 0 0 15px;
//   width: 100%;
//   box-sizing: border-box;
// }

// @media screen and (max-width:768px){
//   .masonryholder{
//     column-count: 1;
//   }
// }
// @media screen and (min-width:769px){
//   .masonryholder{
//     column-count: 2;
//   }
// }
// @media screen and (min-width:1080px){
//   .masonryholder{
//     column-count: 3;
//   }
// }
// @media screen and (min-width:1200px){
//   .masonryholder{
//     column-count: 4;
//   }
// }
// .card-columns {
//   @include media-breakpoint-only(lg) {
//     column-count: 4;
//   }
//   @include media-breakpoint-only(xl) {
//     column-count: 5;
//   }
// }
}
</style>
