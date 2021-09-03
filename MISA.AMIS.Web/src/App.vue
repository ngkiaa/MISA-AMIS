<template>
  <div id="app">
    <Navbar/>
    <Header/>
    <Content/>
  </div>
</template>

<script>
import Navbar from './components/layout/Navbar.vue'
import Header from './components/layout/Header.vue'
import Content from './components/layout/Content.vue'

export default {
  name: 'App',
  components: {
    Navbar,
    Header,
    Content,
  }
}
</script>

<style>
@import url("./style/index.css");
@import url("./style/common/radio.css");
@import url("./style/common/icon.css");
@import url("./style/common/button.css");
</style>
